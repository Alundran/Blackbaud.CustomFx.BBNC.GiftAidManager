'Blackbaud Gift Aid Manager by Derek Marr
'About: This BBNC / BBIS customization will connect to the ScanStore Web Service and allow logged in users tied to RE/CRM records to see if they have a valid declaration with the charity.
'This is a proof of concept.

Imports BBNCExtensions


Partial Public Class BlackbaudGiftAidManagerDisplay
    Inherits BBNCExtensions.Parts.CustomPartDisplayBase

    Private mContent As BlackbaudGiftAidManagerProperties  'We don't actually use this as BBGA credentials are stored in the Infinity DB
    Private mInfinityContent As ViewForms.GiftAidManager.GiftAidManagerViewDataFormData 'We use data forms for grabbing the credentials
    Private isREUser As Boolean 'Are they tied to a back office user account?
    Private userName As String 'Declare the username
    Private password As String 'Declare the password
    Private isValid As Boolean 'Is the page valid to continue?

    Private MyService As ScanStore.ScanStore = New ScanStore.ScanStore 'This is a Web Service reference which is compiled into the DLL.

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyService.Timeout = 100000 'We need to set a timeout for the ScanStore web service
        MyService.Url = "https://scanstoretest.blackbaudhosting.com/scanstoreonline/scanstore.asmx" 'We can alter the URL between Test & Production

        If Not Me.IsPostBack Then
            If Me.Content.InDesignMode Then
                'We could show some sample content here.
                'There is no need to InitializeForm if we're in design mode of BBNC / BBIS.
            Else
                InitializeForm()
            End If

            'Pull the userspecified caption for the header text
            lblCaptionHeader.Text = Me.GetLanguageString("{82759CE9-D01E-4AB3-98F3-A2F57C67418B}")

        End If
    End Sub

    Private Sub InitializeForm()
        If (Not API.Users.CurrentUser.IsAnonymous And API.Users.CurrentUser.RaisersEdgeID > 0) Or API.Users.CurrentUser.UserID = 1 Then 'We only want those who are logged in AND valid back-end
            ValidateBBGAService() 'We need to ensure the BBGA Service is alive and also grab the credentials from the Infinity DB.
            If isValid = True Then 'Based on the procedure above, are we good to proceed?
                isREUser = True 'We've confirmed that the current user has a valid back-end office connection, aka Raiser's Edge or Blackbaud CRM.
                ConsIDText.Text = API.Users.CurrentUser.RaisersEdgeID 'Let's set the Cons ID text box to the ID of back office CRM system
            End If
        Else
            ConsIDLabel.Visible = False 'We don't want to show anything if the user does not match the conditions above
            lblCaptionHeader.Visible = False 'We don't want to show anything if the user does not match the conditions above
            ConsIDText.Visible = False 'We don't want to show anything if the user does not match the conditions above
            Button1.Visible = False 'We don't want to show anything if the user does not match the conditions above
            lblError.Text = "You must be logged in to NetCommunity with an account tied to The Raiser's Edge to view Gift Aid declaration details stored." 'Nice error, huh?
        End If

    End Sub

    Private Sub ValidateBBGAService()
        'This does the initial work of pinging the BBGA (ScanStore) service to make sure it's alive. If it's alive, let's grab the credentials from the back-end Infinity DB.
        isValid = False 'We initially set False
        Try
            Dim Ping As Boolean = MyService.Ping 'Pinging the BBGA Service...
            If Ping = True Then 'We got a response with True, meaning the BBGA Service is up and running
                mInfinityContent = ViewForms.GiftAidManager.GiftAidManagerViewDataForm.LoadData(Me.API.AppFxWebServiceProvider, Me.Content.ContentGuid.ToString) 'Connect to bbAppFx
                userName = mInfinityContent.USERNAME 'Do I need to put a comment here?
                password = mInfinityContent.PASSWORD 'Do I need to put a comment here?
                isValid = True 'We're valid.
                LabelConsoleLog.Text = "ScanStore Service is ONLINE. We are connecting to the following service URL " + MyService.Url 'Debug text
            Else
                isValid = False 'The ping condition returned false, something is up with the BBGA Service.
                lblError.Text = "Blackbaud Gift Aid Service appears to be offline. Please try again later." 'Let's show some feedback error text.
            End If
        Catch ex As Blackbaud.AppFx.WebAPI.AppFxWebServiceException When ex.DataFormErrorInfo IsNot Nothing AndAlso ex.DataFormErrorInfo.ErrorCode = Blackbaud.AppFx.WebAPI.ServiceProxy.DataFormErrorCode.RecordNotFound
            lblError.Text = "Unable validate Blackbaud Gift Aid service." 'We will show this if there is an error with mInfinityContent. Most likely there is no username/password set in the part properties.
            isValid = False 'Return false, we're not good to proceed.
        End Try
        Return
    End Sub

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
        'Define user-editable strings that can be edited on the Language Tab for this part 
        Me.RegisterLanguageField("{82759CE9-D01E-4AB3-98F3-A2F57C67418B}", lblCaptionHeader, "Header Caption", "By ensuring you have a valid Gift Aid declaration with our charity, we can claim the basic rate tax of your gift at no extra cost to you. This means that the value of your donation can be increased by 25% which further helps our efforts.", "Messages", True)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Surname_Label.Visible = True
        Surname_Result_Label.Visible = True
        CreatedOn_Label.Visible = True
        CreatedOn_Result_Label.Visible = True

    End Sub
End Class