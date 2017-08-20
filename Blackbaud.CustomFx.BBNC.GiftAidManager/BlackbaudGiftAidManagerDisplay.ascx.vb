Imports BBNCExtensions


Partial Public Class BlackbaudGiftAidManagerDisplay
    Inherits BBNCExtensions.Parts.CustomPartDisplayBase

    Private mContent As BlackbaudGiftAidManagerProperties
    Private mInfinityContent As ViewForms.GiftAidManager.GiftAidManagerViewDataFormData
    Private isREUser As Boolean
    Private userName As String
    Private password As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            If Me.Content.InDesignMode Then
                'show some sample content?
                'no need to load the form for real while in the CMS page designer
            Else
                InitializeForm()
            End If

            'pull the userspecified caption for the amount due field
            lblCaptionHeader.Text = Me.GetLanguageString("{82759CE9-D01E-4AB3-98F3-A2F57C67418B}")

        End If
    End Sub

    Private Sub InitializeForm()
        If (Not API.Users.CurrentUser.IsAnonymous And API.Users.CurrentUser.RaisersEdgeID > 0) Or API.Users.CurrentUser.UserID = 1 Then
            ValidateBBGAService()
            isREUser = True
            ConsIDText.Text = API.Users.CurrentUser.RaisersEdgeID
        Else
            ConsIDLabel.Visible = False
            lblCaptionHeader.Visible = False
            ConsIDText.Visible = False
            Button1.Visible = False
            lblError.Text = "You must be logged in to NetCommunity with an account tied to The Raiser's Edge to view Gift Aid declaration details stored."
        End If

    End Sub

    Private Sub ValidateBBGAService()
        Try
            mInfinityContent = ViewForms.GiftAidManager.GiftAidManagerViewDataForm.LoadData(Me.API.AppFxWebServiceProvider, Me.Content.ContentGuid.ToString)
            userName = mInfinityContent.USERNAME
            password = mInfinityContent.PASSWORD
        Catch ex As Blackbaud.AppFx.WebAPI.AppFxWebServiceException When ex.DataFormErrorInfo IsNot Nothing AndAlso ex.DataFormErrorInfo.ErrorCode = Blackbaud.AppFx.WebAPI.ServiceProxy.DataFormErrorCode.RecordNotFound
            lblError.Text = "Unable validate Blackbaud Gift Aid service."
            Return
        End Try
        Return
    End Sub

    Public ReadOnly Property IsValid() As Boolean
        Get

            Page.Validate()

            Dim _isValid = Page.IsValid
            Dim validationMessage = String.Empty

            If Not String.IsNullOrEmpty(validationMessage) Then
                _isValid = False
                AddValidationError(validationMessage)
            End If

            Return _isValid
        End Get
    End Property

    Private ReadOnly Property MyContent() As BlackbaudGiftAidManagerProperties
        Get
            If mContent Is Nothing Then
                mContent = Me.Content.GetContent(GetType(BlackbaudGiftAidManagerProperties))
                If mContent Is Nothing Then
                    mContent = New BlackbaudGiftAidManagerProperties
                End If
            End If
            Return mContent
        End Get
    End Property

    Public Overrides Sub RegisterLanguageFields()
        'define user-editable strings that can be edited on the Language Tab for this part 
        Me.RegisterLanguageField("{82759CE9-D01E-4AB3-98F3-A2F57C67418B}", lblCaptionHeader, "Header Caption", "By ensuring you have a valid Gift Aid declaration with our charity, we can claim the basic rate tax of your gift at no extra cost to you. This means that the value of your donation can be increased by 25% which further helps our efforts.", "Messages", True)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


    End Sub
End Class