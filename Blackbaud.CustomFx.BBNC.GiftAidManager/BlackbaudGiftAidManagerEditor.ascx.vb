Imports BBNCExtensions

Partial Public Class BlackbaudGiftAidManagerEditor
    Inherits BBNCExtensions.Parts.CustomPartEditorBase

    Private mContent As BlackbaudGiftAidManagerProperties

    Private Const VS_IS_NEW_PART As String = "IsNewPart"
    Private mIsNewPart As Boolean
    Private mInfinityContent As EditForms.GiftAidManager.GiftAidManagerEditDataFormData
    Private CacheHelper As Blackbaud.AppFx.ContentManagement.Platform.Core.Caching.ICmsCacheItem


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Public Overrides Sub OnLoadContent()
        If Not IsPostBack Then
            UsernameText.Text = MyInfinityContent.USERNAME
        End If
    End Sub

    Public Overrides Function OnSaveContent(Optional ByVal bDialogIsClosing As Boolean = True) As Boolean
        If Me.IsValid Then
            If (UsernameText.Text = "" Or PasswordText.Text = "") Then
                AddValidationError("Required fields are missing. Please ensure you have entered both the username & password.")
            Else
                Try
                    If Me.IsNewPart Then
                        Dim newContentData = New AddForms.GiftAidManager.GiftAidManagerAddDataFormData
                        With newContentData
                            .RecordID = Me.Content.ContentGuid.ToString
                            .USERNAME = UsernameText.Text
                            .PASSWORD = PasswordText.Text
                            .Save(API.AppFxWebServiceProvider)
                        End With
                    Else
                        With MyInfinityContent
                            .USERNAME = UsernameText.Text
                            .PASSWORD = PasswordText.Text
                            .Save(API.AppFxWebServiceProvider)
                        End With
                    End If

                Catch ex As Exception
                    AddValidationError(ex.Message)
                End Try
            End If
        End If
        Return Page.IsValid

    End Function

    Private Sub AddValidationError(ByVal errorMessage As String)
        'add our failed validator to the common validation summary on the dialog
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
                'fetch my content properties from infinity.

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