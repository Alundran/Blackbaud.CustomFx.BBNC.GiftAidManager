Option Infer On
Option Strict Off

Imports bbAppFxWebAPI = Blackbaud.AppFx.WebAPI



Namespace ViewForms

    Namespace [GiftAidManager]
    
		

		    ''' <summary>
    ''' Provides WebApi access to the "Gift Aid Manager View Data Form" catalog feature.  A data form for viewing gift aid manager details
    ''' </summary>
<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2011.8.2.0")> _
        Public NotInheritable Class [GiftAidManagerViewDataForm]

            Private Sub New()
            End Sub

            Private Shared ReadOnly _specId As Guid = New Guid("21c7e0dc-7c8c-48b0-b098-132ea090c2e7")

			''' <summary>
			''' The Spec ID value for the "Gift Aid Manager View Data Form" ViewForm
			''' </summary>
            Public Shared ReadOnly Property SpecId() As Guid
                Get
                    Return _specId
                End Get
            End Property
 
            Public Shared Function CreateRequest(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider) As bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest
                Return CreateRequest(provider, Nothing)
            End Function
            
            Public Shared Function CreateRequest(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal options As bbAppFxWebAPI.LoadRequestOptions) As bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest
                Return Blackbaud.AppFx.WebAPI.DataFormServices.CreateDataFormLoadRequest(provider, _specId, options)
            End Function

            Public Shared Function LoadData(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal recordId As String) As GiftAidManagerViewDataFormData
				Return LoadDataWithOptions(provider, recordId, Nothing)
            End Function

            Public Shared Function LoadDataWithOptions(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal recordId As String, ByVal options As bbAppFxWebAPI.LoadRequestOptions) As GiftAidManagerViewDataFormData

				bbAppFxWebAPI.DataFormServices.ValidateRecordId(recordId)

                Dim request = CreateRequest(provider, options)

				
				
				request.RecordID = recordId

                Return LoadData(provider, request)

            End Function

            Public Shared Function LoadData(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal request As bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest) As GiftAidManagerViewDataFormData
                Return bbAppFxWebAPI.DataFormServices.GetFormData(Of GiftAidManagerViewDataFormData)(provider, request)
            End Function

        End Class

#Region "Data Class"
	
	    ''' <summary>
        ''' Represents the data form field values in the "Gift Aid Manager View Data Form" data form.
        ''' </summary>
		<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2011.8.2.0")> _
	    Public NotInheritable Class GiftAidManagerViewDataFormData
			Inherits bbAppFxWebAPI.ViewFormData
		
			Private [_USERNAME] As String
''' <summary>
''' Username
''' </summary>
Public Property [USERNAME] As String
    Get
        Return Me.[_USERNAME]
    End Get
    Set
        Me.[_USERNAME] = value 
    End Set
End Property

Private [_PASSWORD] As String
''' <summary>
''' Password
''' </summary>
Public Property [PASSWORD] As String
    Get
        Return Me.[_PASSWORD]
    End Get
    Set
        Me.[_PASSWORD] = value 
    End Set
End Property


	        
			Public Sub New()
				MyBase.New()
			End Sub

			Public Sub New(ByVal reply as bbAppFxWebAPI.ServiceProxy.DataFormLoadReply)
				If (reply IsNot Nothing) AndAlso (reply.DataFormItem IsNot Nothing) Then
					Me.SetValues(reply.DataFormItem)
				End If
			End Sub
        
			Public Sub New(ByVal dataFormItemXml As String)
				MyBase.New()
				Me.SetValuesFromDataFormItem(dataFormItemXml)
			End Sub
        
			Public Overrides ReadOnly Property DataFormInstanceID() As System.Guid
				Get
					Return ViewForms.[GiftAidManager].GiftAidManagerViewDataForm.SpecId
				End Get
			End Property
	    
			Friend Sub SetValues(ByVal dfi As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
	            
				
Dim value As Object = Nothing
Dim dfiFieldValue As Blackbaud.AppFx.XmlTypes.DataForms.DataFormFieldValue = Nothing
Dim stringFieldValue As String = Nothing

stringFieldValue = Nothing
If dfi.TryGetValueForPropertyAssignment("USERNAME", stringFieldValue) Then
Me.[USERNAME] = stringFieldValue
End If

stringFieldValue = Nothing
If dfi.TryGetValueForPropertyAssignment("PASSWORD", stringFieldValue) Then
Me.[PASSWORD] = stringFieldValue
End If


	            
			End Sub
				
			Public Overrides Sub SetValuesFromDataFormItem(ByVal dataFormItem As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
				Me.SetValues(dataFormItem)
			End Sub

			
	 
		End Class

#End Region
    
    End Namespace

End Namespace



