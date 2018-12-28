using AnimizerApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Media;
using System.Windows.Forms;


namespace AnimizerTool {

    public enum ImageOrigin { Center, TopLeft, BottomLeft };

    public partial class MainForm : Form {

        static readonly string title = " - Animizer Tool";

        int animCurrentFrame;
        int animFrameWhenPlaying;
        float currentScale;
        string openAnimFile;
        string selectedCellValue;
        string cellEditPreviousName;
        bool changesMade;
        bool animPreviewIsPlaying;
        bool flagEditingDataGridView;
        Dictionary<string, Anim> anims;
        Color boxColor;
        Timer animTimer;
        Image currentImage;
        Rectangle imageRect;
        ImageOrigin imageOrigin;


        public MainForm() {
            InitializeComponent();
            
            anims = new Dictionary<string, Anim>();

            imageOrigin = ImageOrigin.Center;
            imageRect = animPreviewPicture.Bounds;

            // picture frame is just a template, image
            // drawing is done OnPaint for more control
            animPreviewPicture.Enabled = false;
            animPreviewPicture.Visible = false;

            selectedCellValue = "";
            cellEditPreviousName = "";
            animFrameWhenPlaying = 0;
            currentScale = 1;

            boxColor = Color.Red;

            animTimer = new Timer(components);
            animTimer.Tick += new EventHandler(animTimer_Tick);
        }

        #region Menu Items

        private void menuFileNew_Click(object sender, EventArgs e) {
            if (changesMade) {
                DialogResult result = ShowUnsavedChangesMsg();

                if (result == DialogResult.Cancel) {
                    return;
                }
                if (result == DialogResult.Yes) {
                    ProcessSaveAnimFileDialog();
                }
            }

            ClearFormFields();

            openAnimFile = "";
            SetChangesMade(false);
            animFrameWhenPlaying = 0;
            currentScale = 1;
            anims.Clear();

            prevAnimBtn.Enabled = false;
            nextAnimBtn.Enabled = false;
            addAnimFrameBtn.Enabled = false;
            playAnimBtn.Enabled = false;
            centerXTextBox.Enabled = false;
            centerYTextBox.Enabled = false;
            sizeXTextBox.Enabled = false;
            sizeYTextBox.Enabled = false;
            timeFrameCntTextBox.Enabled = false;
            timeFrameRateTextBox.Enabled = false;
            animFrameImageBtn.Enabled = false;

            this.Text = "Untitled" + title;
        }

        private void menuFileOpen_Click(object sender, EventArgs e) {
            if (changesMade) {
                DialogResult saveResult = ShowUnsavedChangesMsg();

                if (saveResult == DialogResult.Cancel) {
                    return;
                }
                if (saveResult == DialogResult.Yes) {
                    ProcessSaveAnimFileDialog();
                }
            }

            DialogResult loadResult = loadAnimFileDialog.ShowDialog();

            if (loadResult == DialogResult.Cancel)
                return;
            
            ClearFormFields();

            anims = LoadAnimFile(loadAnimFileDialog.FileName);

            string filename = Path.GetFileNameWithoutExtension(loadAnimFileDialog.FileName);
            this.Text = filename + title;
            
            foreach (var animKV in anims) {
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                cell.Value = animKV.Key;

                // Create row for single cell
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(cell);

                // Add row to DataGridView
                animDataGridView.Rows.Add(row);
            }

            SetChangesMade(false);
        }

        private void menuSaveAnim_Click(object sender, EventArgs e) {
            if (!changesMade)
                return;

            if (openAnimFile == "") {
                ProcessSaveAnimFileDialog();
            } else {
                SaveAnimFile(openAnimFile);
            }
        }

        private void menuSaveAsAnim_Click(object sender, EventArgs e) {
            ProcessSaveAnimFileDialog();
        }

        private void menuExit_Click(object sender, EventArgs e) {
            if (changesMade) {
                DialogResult result = ShowUnsavedChangesMsg();

                if (result == DialogResult.Cancel) {
                    return;
                }
                if (result == DialogResult.Yes) {
                    if (openAnimFile == "")
                        ProcessSaveAnimFileDialog();
                    else
                        SaveAnimFile(openAnimFile);
                }
            }
            Application.Exit();
        }

        private void menuChangeBoxColor_Click(object sender, EventArgs e) {
            DialogResult result = boxColorDialog.ShowDialog();
            if (result == DialogResult.OK) {
                boxColor = boxColorDialog.Color;
                Invalidate();
            }
        }

        private void menuHelpAbout_Click(object sender, EventArgs e) {
            MessageBox.Show("AnimizerTool - A GUI tool for managing Animizer anims.\n\n" +
                "Created by Fauxtrot. (https://www.github.com/GDFauxtrot)\n\n" +
                "Build date: Dec 24, 2018\n\n\n" +
                "(Don't expect much quality, this is an internal bodge job tool.)",
                "About", MessageBoxButtons.OK);
        }

        #endregion
        #region Anim Buttons

        private void playAnimBtn_Click(object sender, EventArgs e) {
            Anim anim = anims[selectedCellValue];
            int frameCount = anim.frames.Count;

            if (frameCount == 1) // don't bother animating a single frame
                return;

            animPreviewIsPlaying = !animPreviewIsPlaying;

            if (animPreviewIsPlaying)
                animFrameWhenPlaying = animCurrentFrame;
            else
                animCurrentFrame = animFrameWhenPlaying;

            playAnimBtn.Text = animPreviewIsPlaying ? "⏸" : "▶";

            animFrameImageBtn.Enabled = !animPreviewIsPlaying;
            
            addAnimBtn.Enabled = !animPreviewIsPlaying;
            removeAnimBtn.Enabled = !animPreviewIsPlaying;
            centerXTextBox.Enabled = !animPreviewIsPlaying;
            centerYTextBox.Enabled = !animPreviewIsPlaying;
            sizeXTextBox.Enabled = !animPreviewIsPlaying;
            sizeYTextBox.Enabled = !animPreviewIsPlaying;
            timeFrameCntTextBox.Enabled = !animPreviewIsPlaying;
            timeFrameRateTextBox.Enabled = !animPreviewIsPlaying;

            prevAnimBtn.Enabled = !animPreviewIsPlaying && animCurrentFrame > 0;
            nextAnimBtn.Enabled = !animPreviewIsPlaying && animCurrentFrame + 1 < frameCount;
            addAnimFrameBtn.Enabled = !animPreviewIsPlaying;
            removeAnimFrameBtn.Enabled = !animPreviewIsPlaying;

            animTimer.Stop();

            if (animPreviewIsPlaying) {
                animTimer.Interval = (int)
                    ((anim.frames[animCurrentFrame].timeFrames * 1.0f /
                    anim.frames[animCurrentFrame].timeRate) * 1000);

                animTimer.Start();
            } else {
                animFrameLabel.Text = string.Format("Frame {0}/{1}", animCurrentFrame + 1, anim.frames.Count);
                currentImage = Image.FromFile(anim.frames[animCurrentFrame].image);
                Invalidate();
            }
        }

        private void addAnimBtn_Click(object sender, EventArgs e) {
            // Create cell to hold value
            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
            cell.Value = "";

            // Create row for single cell
            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(cell);

            // Add row to DataGridView
            animDataGridView.Rows.Add(row);

            // Select cell for editing
            animDataGridView.CurrentCell = cell;
            animDataGridView.BeginEdit(false);

            SetChangesMade(true);
        }

        private void removeAnimBtn_Click(object sender, EventArgs e) {
            if (selectedCellValue == "")
                return;

            for (int i = 0; i < animDataGridView.Rows.Count; ++i) {
                DataGridViewCell cell = animDataGridView.Rows[i].Cells[0];

                if (((string)cell.Value).Equals(selectedCellValue)) {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete '" +
                        (string) cell.Value + "'?", "Delete Anim",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (result == DialogResult.No) {
                        return;
                    } 

                    anims.Remove((string)cell.Value);
                    animDataGridView.Rows.Remove(animDataGridView.Rows[i]);
                    if (animDataGridView.Rows.Count == 0) {
                        selectedCellValue = "";
                        ClearAllFrameData();

                        animFrameImageBtn.Enabled = false;
                        
                        centerXTextBox.Enabled = false;
                        centerYTextBox.Enabled = false;
                        sizeXTextBox.Enabled = false;
                        sizeYTextBox.Enabled = false;
                        timeFrameCntTextBox.Enabled = false;
                        timeFrameRateTextBox.Enabled = false;
                        playAnimBtn.Enabled = false;
                        prevAnimBtn.Enabled = false;
                        nextAnimBtn.Enabled = false;
                        addAnimFrameBtn.Enabled = false;
                        removeAnimFrameBtn.Enabled = false;
                    }
                    
                    SetChangesMade(true);

                    return;
                }
            }
        }

        private void prevAnimBtn_Click(object sender, EventArgs e) {
            bool changes = changesMade;

            if (animCurrentFrame > 0) {
                LoadAnimFrameData(selectedCellValue, --animCurrentFrame);
                if (animCurrentFrame == 0) {
                    prevAnimBtn.Enabled = false;
                }
            }

            nextAnimBtn.Enabled = true;

            if (!changes)
                SetChangesMade(false);
        }

        private void nextAnimBtn_Click(object sender, EventArgs e) {
            bool changes = changesMade;

            Anim anim = anims[selectedCellValue];
            int frameCount = anim.frames.Count;

            LoadAnimFrameData(selectedCellValue, ++animCurrentFrame);

            prevAnimBtn.Enabled = true;
            removeAnimFrameBtn.Enabled = true;

            nextAnimBtn.Enabled = animCurrentFrame + 1 < anim.frames.Count;

            if (!changes)
                SetChangesMade(false);
        }

        private void addAnimFrameBtn_Click(object sender, EventArgs e) {
            Anim anim = anims[selectedCellValue];
            int frameCount = anim.frames.Count;

            if (animCurrentFrame + 1 == frameCount) {
                // Add anim frame, duplicating the last one
                AnimFrame thisFrame = anim.frames[frameCount-1];

                anim.frames.Add(thisFrame);
                LoadAnimFrameData(selectedCellValue, ++animCurrentFrame);
            } else {
                // Insert anim frame, duplicating the current one
                AnimFrame thisFrame = anim.frames[animCurrentFrame];

                anim.frames.Insert(animCurrentFrame + 1, thisFrame);
                LoadAnimFrameData(selectedCellValue, ++animCurrentFrame);
            }

            removeAnimFrameBtn.Enabled = true;
            prevAnimBtn.Enabled = true;

            SetChangesMade(true);
        }

        private void removeAnimFrameBtn_Click(object sender, EventArgs e) {
            Anim anim = anims[selectedCellValue];
            int frameCount = anim.frames.Count;
            AnimFrame currentFrame = anim.frames[animCurrentFrame];
            anim.frames.Remove(currentFrame);
            if (animCurrentFrame + 1 == frameCount) {
                LoadAnimFrameData(selectedCellValue, --animCurrentFrame);
            } else {
                LoadAnimFrameData(selectedCellValue, animCurrentFrame);
            }
            
            if (anim.frames.Count == 1) {
                nextAnimBtn.Enabled = false;
                prevAnimBtn.Enabled = false;
                removeAnimFrameBtn.Enabled = false;
            }

            SetChangesMade(true);
        }

        private void animFrameImageBtn_Click(object sender, EventArgs e) {
            if (selectedCellValue == "")
                return;

            var result = loadImageFileDialog.ShowDialog();

            if (result == DialogResult.OK) {
                animFrameImageTextBox.Text = loadImageFileDialog.FileName;

                if (currentImage != null)
                    currentImage.Dispose();

                currentImage = Image.FromFile(loadImageFileDialog.FileName);
                //ScaleCurrentImage(currentScale);
                Invalidate();

                AnimFrame frame = anims[selectedCellValue].frames[animCurrentFrame];
                frame.image = loadImageFileDialog.FileName;
                anims[selectedCellValue].frames[animCurrentFrame] = frame;

                SetChangesMade(true);
            }
        }

        #endregion
        #region Text Boxes

        private void centerXTextBox_TextChanged(object sender, EventArgs e) {
            if (selectedCellValue == "")
                return;
            
            int centerX = 0;
            try {
                centerX = centerXTextBox.Text == "" ? 0 : int.Parse(centerXTextBox.Text);
            } catch (FormatException) {
                centerX = 0;
                SystemSounds.Beep.Play();
            }
            
            AnimFrame frame = anims[selectedCellValue].frames[animCurrentFrame];
            frame.centerX = centerX;
            anims[selectedCellValue].frames[animCurrentFrame] = frame;
            Invalidate();

            SetChangesMade(true);
        }

        private void centerYTextBox_TextChanged(object sender, EventArgs e) {
            if (selectedCellValue == "")
                return;
            
            int centerY = 0;
            try {
                centerY = centerYTextBox.Text == "" ? 0 : int.Parse(centerYTextBox.Text);
            } catch (FormatException) {
                centerY = 0;
                SystemSounds.Beep.Play();
            }

            AnimFrame frame = anims[selectedCellValue].frames[animCurrentFrame];
            frame.centerY = centerY;
            anims[selectedCellValue].frames[animCurrentFrame] = frame;
            Invalidate();

            SetChangesMade(true);
        }

        private void sizeXTextBox_TextChanged(object sender, EventArgs e) {
            if (selectedCellValue == "")
                return;
            
            int sizeX = 0;
            try {
                sizeX = sizeXTextBox.Text == "" ? 0 : int.Parse(sizeXTextBox.Text);
            } catch (FormatException) {
                sizeX = 0;
                SystemSounds.Beep.Play();
            }
            
            AnimFrame frame = anims[selectedCellValue].frames[animCurrentFrame];
            frame.sizeX = sizeX;
            anims[selectedCellValue].frames[animCurrentFrame] = frame;
            Invalidate();

            SetChangesMade(true);
        }

        private void sizeYTextBox_TextChanged(object sender, EventArgs e) {
            if (selectedCellValue == "")
                return;
            
            int sizeY = 0;
            try {
                sizeY = sizeYTextBox.Text == "" ? 0 : int.Parse(sizeYTextBox.Text);
            } catch (FormatException) {
                sizeY = 0;
                SystemSounds.Beep.Play();
            }
            
            AnimFrame frame = anims[selectedCellValue].frames[animCurrentFrame];
            frame.sizeY = sizeY;
            anims[selectedCellValue].frames[animCurrentFrame] = frame;
            Invalidate();

            SetChangesMade(true);
        }

        private void timeFrameCntTextBox_TextChanged(object sender, EventArgs e) {
            if (selectedCellValue == "")
                return;
            
            int timeFrames = 0;
            try {
                timeFrames = timeFrameCntTextBox.Text == "" ? 0 : int.Parse(timeFrameCntTextBox.Text);
            } catch (FormatException) {
                timeFrames = 0;
            }

            AnimFrame frame = anims[selectedCellValue].frames[animCurrentFrame];
            frame.timeFrames = timeFrames;
            anims[selectedCellValue].frames[animCurrentFrame] = frame;
            Invalidate();

            timeSecsLabel.Text = string.Format("= {0:0.#####} secs", (timeFrames * 1.0f / frame.timeRate));

            SetChangesMade(true);
        }

        private void timeFrameRateTextBox_TextChanged(object sender, EventArgs e) {
            if (selectedCellValue == "")
                return;
            
            int timeRate = 0;

            try {
                timeRate = timeFrameRateTextBox.Text == "" ? 1 : int.Parse(timeFrameRateTextBox.Text);
            } catch (FormatException) {
                timeRate = 0;
            }

            if (timeRate == 0) {
                timeFrameRateTextBox.Text = "60";
                return;
            }
                

            AnimFrame frame = anims[selectedCellValue].frames[animCurrentFrame];
            frame.timeRate = timeRate;
            anims[selectedCellValue].frames[animCurrentFrame] = frame;
            Invalidate();

            timeSecsLabel.Text = string.Format("= {0:0.#####} secs", (frame.timeFrames * 1.0f / timeRate));

            SetChangesMade(true);
        }
        
        private void scaleTextBox_TextChanged(object sender, EventArgs e) {
            if (currentImage == null)
                return;

            float scale = 1;
            try {
                scale = float.Parse(scaleTextBox.Text);
            } catch (FormatException) {
                SystemSounds.Beep.Play();
            }

            currentScale = scale;
            Invalidate();
        }

        #endregion
        #region Radio Buttons
        
        private void radioCenter_CheckedChanged(object sender, EventArgs e) {
            imageOrigin = ImageOrigin.Center;
            Invalidate();
        }

        private void radioTopLeft_CheckedChanged(object sender, EventArgs e) {
            imageOrigin = ImageOrigin.TopLeft;
            Invalidate();
        }

        private void radioBottomLeft_CheckedChanged(object sender, EventArgs e) {
            imageOrigin = ImageOrigin.BottomLeft;
            Invalidate();
        }

        #endregion
        #region Drawing
        
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            // Border
            GraphicsPath p = new GraphicsPath();
            Rectangle borderRect = imageRect;
            borderRect.X -= 1;
            borderRect.Y -= 1;
            borderRect.Width += 1;
            borderRect.Height += 1;
            p.AddRectangle(borderRect);
            g.DrawPath(new Pen(Color.Black), p);

            Pen redPen = new Pen(Color.Red);

            // Image
            if (currentImage != null) {
                g.Clip = new Region(imageRect);

                Rectangle newRect = new Rectangle(imageRect.X, imageRect.Y,
                    currentImage.Width, currentImage.Height);

                if (imageOrigin == ImageOrigin.Center) {
                    newRect.X += imageRect.Width/2;
                    newRect.Y += imageRect.Height/2;
                }
                if (imageOrigin == ImageOrigin.BottomLeft) {
                    newRect.Y += imageRect.Height;
                }
                if (selectedCellValue != "") {
                    newRect.X -= (int) (anims[selectedCellValue].frames[animCurrentFrame].centerX * currentScale);
                    if (imageOrigin == ImageOrigin.Center) {
                        newRect.Y -= (int) (anims[selectedCellValue].frames[animCurrentFrame].centerY * currentScale);
                    } else {
                        newRect.Y -= (int) (anims[selectedCellValue].frames[animCurrentFrame].centerY * currentScale);
                    }
                }

                newRect.Width = (int)(newRect.Width * currentScale);
                newRect.Height = (int)(newRect.Height * currentScale);

                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half; // needed because... interp decisions

                g.DrawImage(currentImage, newRect);
                
                g.PixelOffsetMode = PixelOffsetMode.Default;
                g.InterpolationMode = InterpolationMode.Default;

                g.ResetClip();
            } else {
                g.DrawLine(redPen,
                    imageRect.X, imageRect.Y,
                    imageRect.X + imageRect.Width,
                    imageRect.Y + imageRect.Height);
                g.DrawLine(redPen,
                    imageRect.X + imageRect.Width,
                    imageRect.Y,
                    imageRect.X,
                    imageRect.Y + imageRect.Height);
            }

            // Cross
            Pen hPen = new Pen(
                    new HatchBrush(HatchStyle.DarkVertical,
                        Color.Transparent, Color.FromArgb(128, 0, 0, 0)));
            Pen vPen = new Pen(
                    new HatchBrush(HatchStyle.DarkHorizontal,
                        Color.Transparent, Color.FromArgb(128, 0, 0, 0)));
            //Pen hPen = new Pen(Color.FromArgb(64, 0, 0, 0));
            //Pen vPen = new Pen(Color.FromArgb(64, 0, 0, 0));

            Point hP1 = new Point(), hP2 = new Point();

            Point vP1 = new Point(imageRect.X,
                    imageRect.Y);
            Point vP2 = new Point(imageRect.X,
                    imageRect.Y + imageRect.Height);

            if (imageOrigin == ImageOrigin.TopLeft) {
                hP1 = new Point(imageRect.X,
                    imageRect.Y);
                hP2 = new Point(imageRect.X + imageRect.Width,
                    imageRect.Y);
            }
            if (imageOrigin == ImageOrigin.BottomLeft) {
                hP1 = new Point(imageRect.X,
                    imageRect.Y + imageRect.Height - 1);
                hP2 = new Point(imageRect.X + imageRect.Width,
                    imageRect.Y + imageRect.Height - 1);
            }
            if (imageOrigin == ImageOrigin.TopLeft ||
                    imageOrigin == ImageOrigin.BottomLeft) {
                vP1 = new Point(imageRect.X,
                    imageRect.Y);
                vP2 = new Point(imageRect.X,
                    imageRect.Y + imageRect.Height);
            }
            if (imageOrigin == ImageOrigin.Center) {
                hP1 = new Point(imageRect.X,
                    imageRect.Y + imageRect.Height/2);
                hP2 = new Point(imageRect.X + imageRect.Width,
                    imageRect.Y + imageRect.Height/2);
                vP1 = new Point(imageRect.X + imageRect.Width/2,
                    imageRect.Y);
                vP2 = new Point(imageRect.X + imageRect.Width/2,
                    imageRect.Y + imageRect.Height);
            }

            g.DrawLine(hPen, hP1, hP2);
            g.DrawLine(vPen, vP1, vP2);

            if (selectedCellValue != "") {
                // Get box rect first
                Rectangle boxRect = new Rectangle();

                int rX = (int) (anims[selectedCellValue].frames[animCurrentFrame].sizeX * currentScale);
                int rY = (int) (anims[selectedCellValue].frames[animCurrentFrame].sizeY * currentScale);

                boxRect.Width = rX;
                boxRect.Height = rY;

                if (imageOrigin == ImageOrigin.Center) {
                    boxRect.X = imageRect.X + imageRect.Width/2 - rX/2;
                    boxRect.Y = imageRect.Y + imageRect.Height/2 - rY/2;
                } else if (imageOrigin == ImageOrigin.TopLeft) {
                    boxRect.X = imageRect.X;
                    boxRect.Y = imageRect.Y;
                } else {
                    boxRect.X = imageRect.X;
                    boxRect.Y = imageRect.Y + imageRect.Width - rY;
                }

                // Anim playing? Dim fill
                if (animPreviewIsPlaying) {
                    GraphicsPath dimOuter = new GraphicsPath();
                    GraphicsPath dimInner = new GraphicsPath();
                    dimOuter.AddRectangle(imageRect);
                    dimInner.AddRectangle(boxRect);

                    Region r = new Region(dimOuter);
                    r.Exclude(dimInner);
                    g.FillRegion(new SolidBrush(Color.FromArgb(128, Color.Black)), r);
                }

                // Size box
                Pen boxPen = new Pen(boxColor);

                g.Clip = new Region(imageRect);
                g.DrawRectangle(boxPen, boxRect);
                g.ResetClip();
            }
        }

        private void animTimer_Tick(object sender, EventArgs e) {
            Anim anim = anims[selectedCellValue];
            if (++animCurrentFrame == anim.frames.Count) {
                animCurrentFrame = 0;
            }
            AnimFrame frame = anim.frames[animCurrentFrame];

            if (currentImage != null)
                currentImage.Dispose();

            currentImage = Image.FromFile(frame.image);

            Invalidate();

            animTimer.Interval = (int)
                ((anim.frames[animCurrentFrame].timeFrames * 1.0f /
                anim.frames[animCurrentFrame].timeRate) * 1000);

            animFrameLabel.Text = string.Format("Frame {0}/{1}", animCurrentFrame + 1, anim.frames.Count);
        }

        #endregion
        #region AnimDataGridView
        
        private void animDataGridView_CurrentCellChanged(object sender, EventArgs e) {
            DataGridViewCell currentCell = animDataGridView.CurrentCell;
            if (currentCell == null ||
                ((string) currentCell.Value).Equals(selectedCellValue) || 
                ((string) currentCell.Value) == "") {
                // current cell didn't actually change (this can happen)
                return;
            }

            bool changes = changesMade;

            SelectAnimCell((string) currentCell.Value);

            // If changes weren't made before, keep it that way
            if (!changes)
                SetChangesMade(false);
        }

        private void animDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex < 0)
                return;
            if (animPreviewIsPlaying)
                return;

            DataGridViewCell cell = animDataGridView.Rows[e.RowIndex].Cells[0];
            
            if (cell.IsInEditMode)
                return;

            animDataGridView.CurrentCell = cell;
            animDataGridView.BeginEdit(false);
        }

        private void animDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            DataGridViewCell editingCell = animDataGridView.Rows[e.RowIndex].Cells[0];

            // If cell name is empty, then this is new - ignore this
            if ((string) editingCell.Value == "")
                return;

            cellEditPreviousName = (string) editingCell.Value;
        }

        private void animDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            // if name already exists, force re-edit to disallow duplicates
            DataGridViewCell editingCell = animDataGridView.Rows[e.RowIndex].Cells[0];
            if (editingCell.Value == null || (string) editingCell.Value == "") {
                // We would delete this cell, but it would be a big issue if
                // a full Anim was made and the cell was saved as an empty
                // string on accident.
                if (!flagEditingDataGridView) {
                    animDataGridView.CurrentCell = editingCell;
                    animDataGridView.BeginEdit(false);
                    SystemSounds.Beep.Play();
                }
                return;
            }
            for (int i = 0; i < animDataGridView.Rows.Count; ++i) {
                DataGridViewCell cell = animDataGridView.Rows[i].Cells[0];
                if (cell != editingCell && cell.Value.Equals(editingCell.Value)) {
                    animDataGridView.CurrentCell = editingCell;
                    animDataGridView.BeginEdit(false);
                    SystemSounds.Beep.Play();
                    return;
                }
            }

            // this could also be a rename - if so, transfer Anim and delete old entry

            if (cellEditPreviousName != (string)editingCell.Value) {
                if (cellEditPreviousName != "") {
                    Anim oldAnim = anims[cellEditPreviousName];
                    oldAnim.id = (string)editingCell.Value;
                    anims.Add((string)editingCell.Value, oldAnim);
                    anims.Remove(cellEditPreviousName);
                }
            }

            SelectAnimCell((string)editingCell.Value);
            cellEditPreviousName = "";

            SetChangesMade(true);
        }

        #endregion
        #region Data, I/O & Form Fields

        void ClearFormFields() {
            if (animDataGridView.CurrentCell != null && (string) animDataGridView.CurrentCell.Value == "") {
                flagEditingDataGridView = true;
                animDataGridView.EndEdit();
                flagEditingDataGridView = false;
            }

            animDataGridView.Rows.Clear();
            ClearAllFrameData();

            cellEditPreviousName = "";
            selectedCellValue = "";
        }

        void ClearAllFrameData() {
            if (currentImage != null)
                currentImage.Dispose();
            currentImage = null;

            animNameLabel.Text = "Name: \"\"";
            animFrameLabel.Text = "Frame n/a";
            centerXTextBox.Text = "";
            centerYTextBox.Text = "";
            sizeXTextBox.Text = "";
            sizeYTextBox.Text = "";
            timeFrameCntTextBox.Text = "";
            timeFrameRateTextBox.Text = "";
            timeSecsLabel.Text = "= 0 secs";
            animFrameImageTextBox.Text = "";
        }
        
        void LoadAnimFrameData(string animName, int frameId) {
            if (!anims.ContainsKey(animName))
                return;
            
            Anim anim = anims[animName];

            if (frameId >= anim.frames.Count || frameId < 0)
                return;

            animCurrentFrame = frameId;
            AnimFrame frame = anim.frames[frameId];

            animFrameLabel.Text = string.Format("Frame {0}/{1}", frameId+1, anim.frames.Count);
            timeSecsLabel.Text = string.Format("= {0:0.#####} secs", (frame.timeFrames * 1.0f / frame.timeRate));

            centerXTextBox.Text = frame.centerX.ToString();
            centerYTextBox.Text = frame.centerY.ToString();
            sizeXTextBox.Text = frame.sizeX.ToString();
            sizeYTextBox.Text = frame.sizeY.ToString();
            timeFrameCntTextBox.Text = frame.timeFrames.ToString();
            timeFrameRateTextBox.Text = frame.timeRate.ToString();

            animFrameImageTextBox.Text = frame.image;

            // No image associated - don't continue
            if (frame.image == "") {
                if (currentImage != null)
                    currentImage.Dispose();
                currentImage = null;
                Invalidate();
                return;
            }
                

            if (!File.Exists(frame.image)) {
                MessageBox.Show("The image file associated with " +
                    "this frame cannot be found:\n\n" + frame.image,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                animFrameImageTextBox.Text = "";
            }

            if (currentImage != null)
                currentImage.Dispose();

            currentImage = Image.FromFile(frame.image);

            Invalidate();
        }
        
        void SelectAnimCell(string cellName) {
            selectedCellValue = cellName;

            // Load up new anim with an empty first frame and bogus data
            if (!anims.ContainsKey(cellName) || anims[cellName].frames.Count == 0) {
                Anim newAnim = new Anim() {
                    id = cellName,
                    frames = new List<AnimFrame>()
                };

                AnimFrame initFrame = new AnimFrame();
                initFrame.centerX = 0;
                initFrame.centerY = 0;
                initFrame.sizeX = 0;
                initFrame.sizeY = 0;
                initFrame.timeFrames = 1;
                initFrame.timeRate = 60;
                initFrame.image = "";
                newAnim.frames.Add(initFrame);

                anims.Add(cellName, newAnim);
            }

            Anim anim = anims[cellName];

            LoadAnimFrameData(cellName, 0);

            animNameLabel.Text = string.Format("Name: \"{0}\"", cellName);

            prevAnimBtn.Enabled = false;
            nextAnimBtn.Enabled = anim.frames.Count > 1;
            addAnimFrameBtn.Enabled = true;
            playAnimBtn.Enabled = true;
            centerXTextBox.Enabled = true;
            centerYTextBox.Enabled = true;
            sizeXTextBox.Enabled = true;
            sizeYTextBox.Enabled = true;
            timeFrameCntTextBox.Enabled = true;
            timeFrameRateTextBox.Enabled = true;
            animFrameImageBtn.Enabled = true;
        }
        
        void SaveAnimFile(string file, bool intoNewAnim = false) {
            openAnimFile = file;
            
            Animizer.CreateAnimSet(anims,
                Path.GetDirectoryName(file),
                Path.GetFileName(file));

            SetChangesMade(false);
        }

        Dictionary<string, Anim> LoadAnimFile(string file) {
            Dictionary<string, Anim> returnAnims =
                Animizer.ReadAnimSet(
                    Path.GetDirectoryName(file),
                    Path.GetFileName(file));

            openAnimFile = file;

            SetChangesMade(false);

            return returnAnims;
        }

        void SetChangesMade(bool changes) {
            changesMade = changes;
            if (changesMade) {
                if (!this.Text.EndsWith("*"))
                    this.Text = this.Text + "*";
            } else {
                if (this.Text.EndsWith("*"))
                    this.Text = this.Text.Remove(this.Text.Length-1,1);
            }
        }

        #endregion
        #region Dialogues
        
        DialogResult ShowUnsavedChangesMsg() {
            return MessageBox.Show(
                "Save changes before closing?",
                "Unsaved Changes",
                MessageBoxButtons.YesNoCancel);
        }

        void ProcessSaveAnimFileDialog() {
            var saveResult = saveAnimFileDialog.ShowDialog();

            if (saveResult == DialogResult.Cancel) {
                return;
            }
            if (saveResult == DialogResult.OK) {
                string file = saveAnimFileDialog.FileName;

                SaveAnimFile(file, true);

                this.Text = Path.GetFileNameWithoutExtension(file) + title;
            }
        }

        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == (Keys.Control | Keys.S)) {
                label1.Focus(); // remove all focus
                menuSaveAnim_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnClosed(EventArgs e) {
            if (changesMade) {
                DialogResult result = ShowUnsavedChangesMsg();

                if (result == DialogResult.Cancel) {
                    return;
                }
                if (result == DialogResult.Yes) {
                    if (openAnimFile == "")
                        ProcessSaveAnimFileDialog();
                    else
                        SaveAnimFile(openAnimFile);
                }
            }
            base.OnClosed(e);
        }
    }
}
