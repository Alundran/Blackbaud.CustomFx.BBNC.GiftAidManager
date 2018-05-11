'Blackbaud Gift Aid Manager by Derek Marr
'About: This BBNC / BBIS customization will connect to the ScanStore Web Service and allow logged in users tied to RE/CRM records to see if they have a valid declaration with the charity.
'This is a proof of concept.

Imports BBNCExtensions

Partial Public Class BlackbaudGiftAidManagerEditor
    Inherits BBNCExtensions.Parts.CustomPartEditorBase

    Private mContent As BlackbaudGiftAidManagerProperties 'We don't actually use this as BBGA credentials are stored in the Infinity DB

    Private Const VS_IS_NEW_PART As String = "IsNewPart"
    Private mIsNewPart As Boolean 'We want to determine if we're editing an existing part of this is a new part we're dealing with.
    Private mInfinityContent As EditForms.GiftAidManager.GiftAidManagerEditDataFormData 'We use data forms for grabbing the credentials


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Public Overrides Sub OnLoadContent()
        If Not IsPostBack Then
            UsernameText.Text = MyInfinityContent.USERNAME 'Let's default the username with the text we get from MyInfinityContent.
        End If
    End Sub

    Public Overrides Function OnSaveContent(Optional ByVal bDialogIsClosing As Boolean = True) As Boolean
        If Me.IsValid Then 'Is this page valid to proceed?
            If (UsernameText.Text = "" Or PasswordText.Text = "") Then 'We don't want the user to continue if the username OR password is blank.
                AddValidationError("Required fields are missing. Please ensure you have entered both the username & password.") 'Shows an error at the top of the part screen
            Else
                Try
                    If Me.IsNewPart Then 'Is this a new part?
                        Dim newContentData = New AddForms.GiftAidManager.GiftAidManagerAddDataFormData 'Let's use an Add Data Form to populate our username/password in the Infinity DB
                        With newContentData
                            .RecordID = Me.Content.ContentGuid.ToString 'Record ID is specific to the part we're looking at
                            .USERNAME = UsernameText.Text 'I don't need to explain this
                            .PASSWORD = PasswordText.Text 'I don't need to explain this
                            .Save(API.AppFxWebServiceProvider) 'We need to save our content back to bbAppFx for the Add Data Form.
                        End With
                    Else
                        With MyInfinityContent 'This is NOT a new part, therefor we are going to edit the existing contents
                            .USERNAME = UsernameText.Text 'I don't need to explain this
                            .PASSWORD = PasswordText.Text 'I don't need to explain this
                            .Save(API.AppFxWebServiceProvider) 'We need to save our content back to bbAppFx for the Add Data Form.
                        End With
                    End If
                Catch ex As Exception
                    AddValidationError(ex.Message) 'Did we catch an exception? Let's add it to the top of the screen which shows part error messages.
                End Try
            End If
        End If
        Return Page.IsValid

    End Function

    Private Sub AddValidationError(ByVal errorMessage As String)
        'Add our failed validator to the common validation summary on the dialog
        Dim validException As New CustomValidator
        validException.Visible = False
        validException.ErrorMessage = errorMessage
        validException.IsValid = False
        validException.ValidationGroup = Me.ValidationGroup
        Me.Controls.Add(validException)
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

    Private ReadOnly Property MyInfinityContent As EditForms.GiftAidManager.GiftAidManagerEditDataFormData
        Get
            If mInfinityContent Is Nothing Then
                'Fetch my content properties from infinity.

                Try
                    mInfinityContent = EditForms.GiftAidManager.GiftAidManagerEditDataForm.LoadData(Me.API.AppFxWebServiceProvider, Me.Content.ContentGuid.ToString)
                Catch ex As Blackbaud.AppFx.WebAPI.AppFxWebServiceException When ex.DataFormErrorInfo IsNot Nothing AndAlso ex.DataFormErrorInfo.ErrorCode = Blackbaud.AppFx.WebAPI.ServiceProxy.DataFormErrorCode.RecordNotFound
                    'first time I've edited this part - this is OK to fail - we'll create new record
                    'all other (unexptected) errors we won't catch for now 
                End Try

                If mInfinityContent Is Nothing Then

                    'new part - save this to view state - we'll need to know this when we save
                    Me.IsNewPart = True

                    mInfinityContent = New EditForms.GiftAidManager.GiftAidManagerEditDataFormData

                    'set some defaults to load the form with
                    mInfinityContent.RecordID = Me.Content.ContentGuid.ToString
                    mInfinityContent.USERNAME = ""
                    mInfinityContent.PASSWORD = ""

                End If

            End If
            Return mInfinityContent
        End Get
    End Property

    Public Property IsNewPart() As Boolean
        'true if this part's content has not been saved in the infinity db yet
        Get
            If ViewState(VS_IS_NEW_PART) IsNot Nothing Then
                mIsNewPart = CBool(ViewState(VS_IS_NEW_PART))
            End If
            Return mIsNewPart
        End Get
        Set(ByVal value As Boolean)
            ViewState(VS_IS_NEW_PART) = value
        End Set
    End Property

End Class