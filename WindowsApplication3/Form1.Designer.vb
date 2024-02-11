<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormATHFinder
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ORTextBox = New System.Windows.Forms.TextBox()
        Me.Search = New System.Windows.Forms.Button()
        Me.Changer = New System.Windows.Forms.Button()
        Me.CheminDossier = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Ouvrir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.StatusDate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BoxORStatus = New System.Windows.Forms.TextBox()
        Me.LabelStatus = New System.Windows.Forms.Label()
        Me.ATHStatus = New System.Windows.Forms.TextBox()
        Me.CopyATH = New System.Windows.Forms.Button()
        Me.LabelATHRef = New System.Windows.Forms.Label()
        Me.ATHRef = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numéro OR"
        '
        'ORTextBox
        '
        Me.ORTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ORTextBox.Location = New System.Drawing.Point(15, 31)
        Me.ORTextBox.Name = "ORTextBox"
        Me.ORTextBox.Size = New System.Drawing.Size(315, 20)
        Me.ORTextBox.TabIndex = 1
        '
        'Search
        '
        Me.Search.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Search.Location = New System.Drawing.Point(337, 30)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(75, 23)
        Me.Search.TabIndex = 2
        Me.Search.Text = "Chercher"
        Me.Search.UseVisualStyleBackColor = True
        '
        'Changer
        '
        Me.Changer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Changer.Location = New System.Drawing.Point(337, 77)
        Me.Changer.Name = "Changer"
        Me.Changer.Size = New System.Drawing.Size(75, 23)
        Me.Changer.TabIndex = 5
        Me.Changer.Text = "Modifier"
        Me.Changer.UseVisualStyleBackColor = True
        '
        'CheminDossier
        '
        Me.CheminDossier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheminDossier.Location = New System.Drawing.Point(15, 78)
        Me.CheminDossier.Name = "CheminDossier"
        Me.CheminDossier.Size = New System.Drawing.Size(315, 20)
        Me.CheminDossier.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Dossier Fleetbox"
        '
        'Ouvrir
        '
        Me.Ouvrir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ouvrir.Enabled = False
        Me.Ouvrir.Location = New System.Drawing.Point(15, 218)
        Me.Ouvrir.Name = "Ouvrir"
        Me.Ouvrir.Size = New System.Drawing.Size(397, 23)
        Me.Ouvrir.TabIndex = 6
        Me.Ouvrir.Text = "Ouvrir fichier(s) XML"
        Me.Ouvrir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.StatusDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.BoxORStatus)
        Me.GroupBox1.Controls.Add(Me.LabelStatus)
        Me.GroupBox1.Controls.Add(Me.ATHStatus)
        Me.GroupBox1.Controls.Add(Me.CopyATH)
        Me.GroupBox1.Controls.Add(Me.LabelATHRef)
        Me.GroupBox1.Controls.Add(Me.ATHRef)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 106)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(403, 100)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informations"
        '
        'StatusDate
        '
        Me.StatusDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StatusDate.Enabled = False
        Me.StatusDate.HideSelection = False
        Me.StatusDate.Location = New System.Drawing.Point(277, 46)
        Me.StatusDate.Name = "StatusDate"
        Me.StatusDate.ReadOnly = True
        Me.StatusDate.Size = New System.Drawing.Size(114, 13)
        Me.StatusDate.TabIndex = 7
        Me.StatusDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "État OR"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BoxORStatus
        '
        Me.BoxORStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BoxORStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.BoxORStatus.Enabled = False
        Me.BoxORStatus.HideSelection = False
        Me.BoxORStatus.Location = New System.Drawing.Point(95, 68)
        Me.BoxORStatus.Name = "BoxORStatus"
        Me.BoxORStatus.ReadOnly = True
        Me.BoxORStatus.Size = New System.Drawing.Size(215, 13)
        Me.BoxORStatus.TabIndex = 5
        '
        'LabelStatus
        '
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.Location = New System.Drawing.Point(7, 46)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(73, 13)
        Me.LabelStatus.TabIndex = 4
        Me.LabelStatus.Text = "État demande"
        Me.LabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ATHStatus
        '
        Me.ATHStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ATHStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ATHStatus.Enabled = False
        Me.ATHStatus.HideSelection = False
        Me.ATHStatus.Location = New System.Drawing.Point(95, 46)
        Me.ATHStatus.Name = "ATHStatus"
        Me.ATHStatus.ReadOnly = True
        Me.ATHStatus.Size = New System.Drawing.Size(176, 13)
        Me.ATHStatus.TabIndex = 3
        '
        'CopyATH
        '
        Me.CopyATH.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CopyATH.Enabled = False
        Me.CopyATH.Location = New System.Drawing.Point(322, 18)
        Me.CopyATH.Name = "CopyATH"
        Me.CopyATH.Size = New System.Drawing.Size(69, 23)
        Me.CopyATH.TabIndex = 2
        Me.CopyATH.Text = "Copier"
        Me.CopyATH.UseVisualStyleBackColor = True
        '
        'LabelATHRef
        '
        Me.LabelATHRef.AutoSize = True
        Me.LabelATHRef.Location = New System.Drawing.Point(7, 23)
        Me.LabelATHRef.Name = "LabelATHRef"
        Me.LabelATHRef.Size = New System.Drawing.Size(82, 13)
        Me.LabelATHRef.TabIndex = 1
        Me.LabelATHRef.Text = "Référence ATH"
        Me.LabelATHRef.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ATHRef
        '
        Me.ATHRef.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ATHRef.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ATHRef.Location = New System.Drawing.Point(95, 23)
        Me.ATHRef.Name = "ATHRef"
        Me.ATHRef.ReadOnly = True
        Me.ATHRef.ShortcutsEnabled = False
        Me.ATHRef.Size = New System.Drawing.Size(220, 13)
        Me.ATHRef.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(0, 247)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(425, 30)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "ATH Finder by Asmir - Pour Solware 2024"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormATHFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(425, 277)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Ouvrir)
        Me.Controls.Add(Me.Changer)
        Me.Controls.Add(Me.CheminDossier)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.ORTextBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormATHFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ATH Finder"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ORTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Search As System.Windows.Forms.Button
    Friend WithEvents Changer As System.Windows.Forms.Button
    Friend WithEvents CheminDossier As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Ouvrir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelATHRef As System.Windows.Forms.Label
    Friend WithEvents ATHRef As System.Windows.Forms.TextBox
    Friend WithEvents CopyATH As System.Windows.Forms.Button
    Friend WithEvents LabelStatus As System.Windows.Forms.Label
    Friend WithEvents ATHStatus As System.Windows.Forms.TextBox
    Friend WithEvents StatusDate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BoxORStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
