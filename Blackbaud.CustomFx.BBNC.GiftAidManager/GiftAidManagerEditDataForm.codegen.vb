Option Infer On
Option Strict Off

Imports bbAppFxWebAPI = Blackbaud.AppFx.WebAPI



Namespace EditForms

    Namespace [GiftAidManager]
    
		

		

		    ''' <summary>
    ''' Provides WebApi access to the "Gift Aid Manager Edit Data Form" catalog feature.  A data form for editing gift aid manager records
    ''' </summary>
<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2011.8.2.0")> _
        Public NotInheritable Class [GiftAidManagerEditDataForm]

            Private Sub New()
            End Sub

            Private Shared ReadOnly _specId As Guid = New Guid("7fdf59e8-b5e8-42ce-be57-3f563c3cb565")

			''' <summary>
			''' The Spec ID value for the "Gift Aid Manager Edit Data Form" EditForm
			''' </summary>
            Public Shared ReadOnly Property SpecId() As Guid
                Get
                    Return _specId
                End Get
            End Property
 
            Public Shared Function CreateLoadRequest(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider) As bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest
                Return CreateLoadRequest(provider, Nothing)
            End Function

            Public Shared Function CreateLoadRequest(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal options as bbAppFxWebAPI.LoadRequestOptions) As bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest
                Return Blackbaud.AppFx.WebAPI.DataFormServices.CreateDataFormLoadRequest(provider, _specId, options)
            End Function

            Public Shared Function LoadData(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal recordID As String) As GiftAidManagerEditDataFormData
                Return LoadDataWithOptions(provider, recordID, Nothing)
            End Function

            Public Shared Function LoadDataWithOptions(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal recordID As String, ByVal options As bbAppFxWebAPI.LoadRequestOptions) As GiftAidManagerEditDataFormData

				

                Dim request = CreateLoadRequest(provider, options)

				
				
				 request.RecordID = recordID

                Return LoadData(provider, request)

            End Function

            Public Shared Function LoadData(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal request As bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest) As GiftAidManagerEditDataFormData
                Return bbAppFxWebAPI.DataFormServices.GetFormData(Of GiftAidManagerEditDataFormData)(provider, request)
            End Function

        End Class

#Region "Data Class"
	
	    ''' <summary>
        ''' Represents the data form field values in the "Gift Aid Manager Edit Data Form" data form.
        ''' </summary>
	    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2011.8.2.0")> _
	    Public NotInheritable Class GiftAidManagerEditDataFormData
			Inherits bbAppFxWebAPI.EditFormData
		
#Region "Constructors"
		       
			Public Sub New()
				Mybase.New(Nothing)
			End Sub

			Friend Sub New(ByVal reply as bbAppFxWebAPI.ServiceProxy.DataFormLoadReply,request as bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest)
				Mybase.New(request.RecordID)
				If (reply IsNot Nothing) AndAlso (reply.DataFormItem IsNot Nothing) Then
					Me.SetValues(reply.DataFormItem)
				End If
			End Sub
	        
			Public Sub New(ByVal dfi as Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
				Mybase.New()					
				If dfi IsNot Nothing Then
					Me.SetValues(dfi)
				End If
			End Sub
			
			Public Sub New(ByVal dataFormItemXml As String)
				MyBase.New()
				Me.SetValuesFromDataFormItem(dataFormItemXml)
			End Sub

#End Region
        
#Region "Form Field Properties"
		
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


        
#End Region
	        
			Public Overrides ReadOnly Property DataFormInstanceID() As System.Guid
				Get
					Return EditForms.[GiftAidManager].GiftAidManagerEditDataForm.SpecId
				End Get
			End Property

			Public Overrides Function ToDataFormItem() As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem
				Return Me.BuildDataFormItemForSave()
			End Function

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

			Private Function BuildDataFormItemForSave() As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem

				Dim dfi As New Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem

				Dim value As Object = Nothing
value = Me.[USERNAME]
	dfi.SetValueIfNotNull("USERNAME",value)
value = Me.[PASSWORD]
	dfi.SetValueIfNotNull("PASSWORD",value)


				Return dfi

			End Function
	        
			Public Overrides Sub SetValuesFromDataFormItem(ByVal dataFormItem As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
				Me.SetValues(dataFormItem)
			End Sub

	
	 
		End Class

#End Region
    
    End Namespace

End Namespace


