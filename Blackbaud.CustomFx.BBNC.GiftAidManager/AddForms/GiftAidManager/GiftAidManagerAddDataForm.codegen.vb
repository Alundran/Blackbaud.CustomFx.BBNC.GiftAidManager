Option Infer On
Option Strict Off

Imports bbAppFxWebAPI = Blackbaud.AppFx.WebAPI



Namespace AddForms

    Namespace [GiftAidManager]
    
		

		

		    ''' <summary>
    ''' Provides WebApi access to the "Gift Aid Manager Add Data Form" catalog feature.  A data form for adding gift aid manager records
    ''' </summary>
<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2011.8.2.0")> _
        Public NotInheritable Class [GiftAidManagerAddDataForm]

            Private Sub New()
            End Sub

            Private Shared ReadOnly _specId As Guid = New Guid("67f24ecb-9a8f-4b7d-a444-8363cc30bbe4")

			''' <summary>
			''' The Spec ID value for the "Gift Aid Manager Add Data Form" AddForm
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

            ''' <summary>
            ''' Returns an instance of GiftAidManagerAddDataFormData with default data form fields populated.
            ''' </summary>
            ''' <returns>An instance of GiftAidManagerAddDataFormData with the form field properties that have defaults populated with those default values.</returns>
            ''' <remarks>This function will make a web request to the AppFx WebService DataFormLoad method to obtain the default data form field values.</remarks>
            Public Shared Function LoadData(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider) As GiftAidManagerAddDataFormData
                Return LoadDataWithOptions(provider, Nothing)
            End Function

            ''' <summary>
            ''' Returns an instance of GiftAidManagerAddDataFormData with default data form fields populated.
            ''' </summary>
            ''' <returns>An instance of GiftAidManagerAddDataFormData with the form field properties that have defaults populated with those default values.</returns>
            ''' <remarks>This function will make a web request to the AppFx WebService DataFormLoad method to obtain the default data form field values.</remarks>
            Public Shared Function LoadDataWithOptions(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal options As bbAppFxWebAPI.LoadRequestOptions) As GiftAidManagerAddDataFormData

				

                Dim request = CreateLoadRequest(provider, options)

				
				
				

                Return LoadData(provider, request)

            End Function

            ''' <summary>
            ''' Returns an instance of GiftAidManagerAddDataFormData with default data form fields populated.
            ''' </summary>
            ''' <returns>An instance of GiftAidManagerAddDataFormData with the form field properties that have defaults populated with those default values.</returns>
            ''' <remarks>This function will make a web request to the AppFx WebService DataFormLoad method to obtain the default data form field values.</remarks>
            Public Shared Function LoadData(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal request As bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest) As GiftAidManagerAddDataFormData
                Return bbAppFxWebAPI.DataFormServices.GetFormData(Of GiftAidManagerAddDataFormData)(provider, request)
            End Function
   
        End Class

#Region "Data Class"

        ''' <summary>
        ''' Represents the data form field values in the "Gift Aid Manager Add Data Form" data form.
        ''' </summary>
		<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2011.8.2.0")> _
	    Public NotInheritable Class GiftAidManagerAddDataFormData
			Inherits bbAppFxWebAPI.AddFormData
        
#Region "Constructors"
        
			Public Sub New()
				Mybase.New()
			End Sub

			Friend Sub New(ByVal reply as bbAppFxWebAPI.ServiceProxy.DataFormLoadReply,request as bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest)
				Mybase.New()					
				If (reply IsNot Nothing) AndAlso (reply.DataFormItem IsNot Nothing) Then
					Me.SetValues(reply.DataFormItem)
				End If
			End Sub
        
        	Public Sub New(ByVal dfi as Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
				Mybase.New()					
				Me.SetValues(dfi)
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
                    Return AddForms.[GiftAidManager].GiftAidManagerAddDataForm.SpecId
                End Get
            End Property

            Public Overrides Function ToDataFormItem() As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem
                Return Me.BuildDataFormItemForSave()
            End Function
    
			Friend Sub SetValues(ByVal dfi As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
				
				If dfi Is Nothing Then Exit Sub
	            
				
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

