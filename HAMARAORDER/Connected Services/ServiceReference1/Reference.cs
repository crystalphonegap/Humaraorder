﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HAMARAORDER.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.WebServiceSoap")]
    public interface WebServiceSoap {
        
        // CODEGEN: Generating message contract since element name StrUsername from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Password", ReplyAction="*")]
        HAMARAORDER.ServiceReference1.PasswordResponse Password(HAMARAORDER.ServiceReference1.PasswordRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Password", ReplyAction="*")]
        System.Threading.Tasks.Task<HAMARAORDER.ServiceReference1.PasswordResponse> PasswordAsync(HAMARAORDER.ServiceReference1.PasswordRequest request);
        
        // CODEGEN: Generating message contract since element name StrUsername from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Login", ReplyAction="*")]
        HAMARAORDER.ServiceReference1.LoginResponse Login(HAMARAORDER.ServiceReference1.LoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Login", ReplyAction="*")]
        System.Threading.Tasks.Task<HAMARAORDER.ServiceReference1.LoginResponse> LoginAsync(HAMARAORDER.ServiceReference1.LoginRequest request);
        
        // CODEGEN: Generating message contract since element name StrUsername from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LoginValidity", ReplyAction="*")]
        HAMARAORDER.ServiceReference1.LoginValidityResponse LoginValidity(HAMARAORDER.ServiceReference1.LoginValidityRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LoginValidity", ReplyAction="*")]
        System.Threading.Tasks.Task<HAMARAORDER.ServiceReference1.LoginValidityResponse> LoginValidityAsync(HAMARAORDER.ServiceReference1.LoginValidityRequest request);
        
        // CODEGEN: Generating message contract since element name StrUsername from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ForgetPassword", ReplyAction="*")]
        HAMARAORDER.ServiceReference1.ForgetPasswordResponse ForgetPassword(HAMARAORDER.ServiceReference1.ForgetPasswordRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ForgetPassword", ReplyAction="*")]
        System.Threading.Tasks.Task<HAMARAORDER.ServiceReference1.ForgetPasswordResponse> ForgetPasswordAsync(HAMARAORDER.ServiceReference1.ForgetPasswordRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PasswordRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Password", Namespace="http://tempuri.org/", Order=0)]
        public HAMARAORDER.ServiceReference1.PasswordRequestBody Body;
        
        public PasswordRequest() {
        }
        
        public PasswordRequest(HAMARAORDER.ServiceReference1.PasswordRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class PasswordRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string StrUsername;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string StrMobileNo;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string StrApplName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string StrApplCode;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string StrEmailId;
        
        public PasswordRequestBody() {
        }
        
        public PasswordRequestBody(string StrUsername, string StrMobileNo, string StrApplName, string StrApplCode, string StrEmailId) {
            this.StrUsername = StrUsername;
            this.StrMobileNo = StrMobileNo;
            this.StrApplName = StrApplName;
            this.StrApplCode = StrApplCode;
            this.StrEmailId = StrEmailId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PasswordResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PasswordResponse", Namespace="http://tempuri.org/", Order=0)]
        public HAMARAORDER.ServiceReference1.PasswordResponseBody Body;
        
        public PasswordResponse() {
        }
        
        public PasswordResponse(HAMARAORDER.ServiceReference1.PasswordResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class PasswordResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool PasswordResult;
        
        public PasswordResponseBody() {
        }
        
        public PasswordResponseBody(bool PasswordResult) {
            this.PasswordResult = PasswordResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoginRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Login", Namespace="http://tempuri.org/", Order=0)]
        public HAMARAORDER.ServiceReference1.LoginRequestBody Body;
        
        public LoginRequest() {
        }
        
        public LoginRequest(HAMARAORDER.ServiceReference1.LoginRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class LoginRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string StrUsername;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string StrPassword;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string StrApplName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string StrApplCode;
        
        public LoginRequestBody() {
        }
        
        public LoginRequestBody(string StrUsername, string StrPassword, string StrApplName, string StrApplCode) {
            this.StrUsername = StrUsername;
            this.StrPassword = StrPassword;
            this.StrApplName = StrApplName;
            this.StrApplCode = StrApplCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoginResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LoginResponse", Namespace="http://tempuri.org/", Order=0)]
        public HAMARAORDER.ServiceReference1.LoginResponseBody Body;
        
        public LoginResponse() {
        }
        
        public LoginResponse(HAMARAORDER.ServiceReference1.LoginResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class LoginResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool LoginResult;
        
        public LoginResponseBody() {
        }
        
        public LoginResponseBody(bool LoginResult) {
            this.LoginResult = LoginResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoginValidityRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LoginValidity", Namespace="http://tempuri.org/", Order=0)]
        public HAMARAORDER.ServiceReference1.LoginValidityRequestBody Body;
        
        public LoginValidityRequest() {
        }
        
        public LoginValidityRequest(HAMARAORDER.ServiceReference1.LoginValidityRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class LoginValidityRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string StrUsername;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string StrPassword;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string StrApplName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string StrApplCode;
        
        public LoginValidityRequestBody() {
        }
        
        public LoginValidityRequestBody(string StrUsername, string StrPassword, string StrApplName, string StrApplCode) {
            this.StrUsername = StrUsername;
            this.StrPassword = StrPassword;
            this.StrApplName = StrApplName;
            this.StrApplCode = StrApplCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoginValidityResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LoginValidityResponse", Namespace="http://tempuri.org/", Order=0)]
        public HAMARAORDER.ServiceReference1.LoginValidityResponseBody Body;
        
        public LoginValidityResponse() {
        }
        
        public LoginValidityResponse(HAMARAORDER.ServiceReference1.LoginValidityResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class LoginValidityResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool LoginValidityResult;
        
        public LoginValidityResponseBody() {
        }
        
        public LoginValidityResponseBody(bool LoginValidityResult) {
            this.LoginValidityResult = LoginValidityResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ForgetPasswordRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ForgetPassword", Namespace="http://tempuri.org/", Order=0)]
        public HAMARAORDER.ServiceReference1.ForgetPasswordRequestBody Body;
        
        public ForgetPasswordRequest() {
        }
        
        public ForgetPasswordRequest(HAMARAORDER.ServiceReference1.ForgetPasswordRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ForgetPasswordRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string StrUsername;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string StrMobileNo;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string StrApplName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string StrApplCode;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string StrEmailId;
        
        public ForgetPasswordRequestBody() {
        }
        
        public ForgetPasswordRequestBody(string StrUsername, string StrMobileNo, string StrApplName, string StrApplCode, string StrEmailId) {
            this.StrUsername = StrUsername;
            this.StrMobileNo = StrMobileNo;
            this.StrApplName = StrApplName;
            this.StrApplCode = StrApplCode;
            this.StrEmailId = StrEmailId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ForgetPasswordResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ForgetPasswordResponse", Namespace="http://tempuri.org/", Order=0)]
        public HAMARAORDER.ServiceReference1.ForgetPasswordResponseBody Body;
        
        public ForgetPasswordResponse() {
        }
        
        public ForgetPasswordResponse(HAMARAORDER.ServiceReference1.ForgetPasswordResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ForgetPasswordResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool ForgetPasswordResult;
        
        public ForgetPasswordResponseBody() {
        }
        
        public ForgetPasswordResponseBody(bool ForgetPasswordResult) {
            this.ForgetPasswordResult = ForgetPasswordResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServiceSoapChannel : HAMARAORDER.ServiceReference1.WebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceSoapClient : System.ServiceModel.ClientBase<HAMARAORDER.ServiceReference1.WebServiceSoap>, HAMARAORDER.ServiceReference1.WebServiceSoap {
        
        public WebServiceSoapClient() {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HAMARAORDER.ServiceReference1.PasswordResponse HAMARAORDER.ServiceReference1.WebServiceSoap.Password(HAMARAORDER.ServiceReference1.PasswordRequest request) {
            return base.Channel.Password(request);
        }
        
        public bool Password(string StrUsername, string StrMobileNo, string StrApplName, string StrApplCode, string StrEmailId) {
            HAMARAORDER.ServiceReference1.PasswordRequest inValue = new HAMARAORDER.ServiceReference1.PasswordRequest();
            inValue.Body = new HAMARAORDER.ServiceReference1.PasswordRequestBody();
            inValue.Body.StrUsername = StrUsername;
            inValue.Body.StrMobileNo = StrMobileNo;
            inValue.Body.StrApplName = StrApplName;
            inValue.Body.StrApplCode = StrApplCode;
            inValue.Body.StrEmailId = StrEmailId;
            HAMARAORDER.ServiceReference1.PasswordResponse retVal = ((HAMARAORDER.ServiceReference1.WebServiceSoap)(this)).Password(inValue);
            return retVal.Body.PasswordResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HAMARAORDER.ServiceReference1.PasswordResponse> HAMARAORDER.ServiceReference1.WebServiceSoap.PasswordAsync(HAMARAORDER.ServiceReference1.PasswordRequest request) {
            return base.Channel.PasswordAsync(request);
        }
        
        public System.Threading.Tasks.Task<HAMARAORDER.ServiceReference1.PasswordResponse> PasswordAsync(string StrUsername, string StrMobileNo, string StrApplName, string StrApplCode, string StrEmailId) {
            HAMARAORDER.ServiceReference1.PasswordRequest inValue = new HAMARAORDER.ServiceReference1.PasswordRequest();
            inValue.Body = new HAMARAORDER.ServiceReference1.PasswordRequestBody();
            inValue.Body.StrUsername = StrUsername;
            inValue.Body.StrMobileNo = StrMobileNo;
            inValue.Body.StrApplName = StrApplName;
            inValue.Body.StrApplCode = StrApplCode;
            inValue.Body.StrEmailId = StrEmailId;
            return ((HAMARAORDER.ServiceReference1.WebServiceSoap)(this)).PasswordAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HAMARAORDER.ServiceReference1.LoginResponse HAMARAORDER.ServiceReference1.WebServiceSoap.Login(HAMARAORDER.ServiceReference1.LoginRequest request) {
            return base.Channel.Login(request);
        }
        
        public bool Login(string StrUsername, string StrPassword, string StrApplName, string StrApplCode) {
            HAMARAORDER.ServiceReference1.LoginRequest inValue = new HAMARAORDER.ServiceReference1.LoginRequest();
            inValue.Body = new HAMARAORDER.ServiceReference1.LoginRequestBody();
            inValue.Body.StrUsername = StrUsername;
            inValue.Body.StrPassword = StrPassword;
            inValue.Body.StrApplName = StrApplName;
            inValue.Body.StrApplCode = StrApplCode;
            HAMARAORDER.ServiceReference1.LoginResponse retVal = ((HAMARAORDER.ServiceReference1.WebServiceSoap)(this)).Login(inValue);
            return retVal.Body.LoginResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HAMARAORDER.ServiceReference1.LoginResponse> HAMARAORDER.ServiceReference1.WebServiceSoap.LoginAsync(HAMARAORDER.ServiceReference1.LoginRequest request) {
            return base.Channel.LoginAsync(request);
        }
        
        public System.Threading.Tasks.Task<HAMARAORDER.ServiceReference1.LoginResponse> LoginAsync(string StrUsername, string StrPassword, string StrApplName, string StrApplCode) {
            HAMARAORDER.ServiceReference1.LoginRequest inValue = new HAMARAORDER.ServiceReference1.LoginRequest();
            inValue.Body = new HAMARAORDER.ServiceReference1.LoginRequestBody();
            inValue.Body.StrUsername = StrUsername;
            inValue.Body.StrPassword = StrPassword;
            inValue.Body.StrApplName = StrApplName;
            inValue.Body.StrApplCode = StrApplCode;
            return ((HAMARAORDER.ServiceReference1.WebServiceSoap)(this)).LoginAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HAMARAORDER.ServiceReference1.LoginValidityResponse HAMARAORDER.ServiceReference1.WebServiceSoap.LoginValidity(HAMARAORDER.ServiceReference1.LoginValidityRequest request) {
            return base.Channel.LoginValidity(request);
        }
        
        public bool LoginValidity(string StrUsername, string StrPassword, string StrApplName, string StrApplCode) {
            HAMARAORDER.ServiceReference1.LoginValidityRequest inValue = new HAMARAORDER.ServiceReference1.LoginValidityRequest();
            inValue.Body = new HAMARAORDER.ServiceReference1.LoginValidityRequestBody();
            inValue.Body.StrUsername = StrUsername;
            inValue.Body.StrPassword = StrPassword;
            inValue.Body.StrApplName = StrApplName;
            inValue.Body.StrApplCode = StrApplCode;
            HAMARAORDER.ServiceReference1.LoginValidityResponse retVal = ((HAMARAORDER.ServiceReference1.WebServiceSoap)(this)).LoginValidity(inValue);
            return retVal.Body.LoginValidityResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HAMARAORDER.ServiceReference1.LoginValidityResponse> HAMARAORDER.ServiceReference1.WebServiceSoap.LoginValidityAsync(HAMARAORDER.ServiceReference1.LoginValidityRequest request) {
            return base.Channel.LoginValidityAsync(request);
        }
        
        public System.Threading.Tasks.Task<HAMARAORDER.ServiceReference1.LoginValidityResponse> LoginValidityAsync(string StrUsername, string StrPassword, string StrApplName, string StrApplCode) {
            HAMARAORDER.ServiceReference1.LoginValidityRequest inValue = new HAMARAORDER.ServiceReference1.LoginValidityRequest();
            inValue.Body = new HAMARAORDER.ServiceReference1.LoginValidityRequestBody();
            inValue.Body.StrUsername = StrUsername;
            inValue.Body.StrPassword = StrPassword;
            inValue.Body.StrApplName = StrApplName;
            inValue.Body.StrApplCode = StrApplCode;
            return ((HAMARAORDER.ServiceReference1.WebServiceSoap)(this)).LoginValidityAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HAMARAORDER.ServiceReference1.ForgetPasswordResponse HAMARAORDER.ServiceReference1.WebServiceSoap.ForgetPassword(HAMARAORDER.ServiceReference1.ForgetPasswordRequest request) {
            return base.Channel.ForgetPassword(request);
        }
        
        public bool ForgetPassword(string StrUsername, string StrMobileNo, string StrApplName, string StrApplCode, string StrEmailId) {
            HAMARAORDER.ServiceReference1.ForgetPasswordRequest inValue = new HAMARAORDER.ServiceReference1.ForgetPasswordRequest();
            inValue.Body = new HAMARAORDER.ServiceReference1.ForgetPasswordRequestBody();
            inValue.Body.StrUsername = StrUsername;
            inValue.Body.StrMobileNo = StrMobileNo;
            inValue.Body.StrApplName = StrApplName;
            inValue.Body.StrApplCode = StrApplCode;
            inValue.Body.StrEmailId = StrEmailId;
            HAMARAORDER.ServiceReference1.ForgetPasswordResponse retVal = ((HAMARAORDER.ServiceReference1.WebServiceSoap)(this)).ForgetPassword(inValue);
            return retVal.Body.ForgetPasswordResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HAMARAORDER.ServiceReference1.ForgetPasswordResponse> HAMARAORDER.ServiceReference1.WebServiceSoap.ForgetPasswordAsync(HAMARAORDER.ServiceReference1.ForgetPasswordRequest request) {
            return base.Channel.ForgetPasswordAsync(request);
        }
        
        public System.Threading.Tasks.Task<HAMARAORDER.ServiceReference1.ForgetPasswordResponse> ForgetPasswordAsync(string StrUsername, string StrMobileNo, string StrApplName, string StrApplCode, string StrEmailId) {
            HAMARAORDER.ServiceReference1.ForgetPasswordRequest inValue = new HAMARAORDER.ServiceReference1.ForgetPasswordRequest();
            inValue.Body = new HAMARAORDER.ServiceReference1.ForgetPasswordRequestBody();
            inValue.Body.StrUsername = StrUsername;
            inValue.Body.StrMobileNo = StrMobileNo;
            inValue.Body.StrApplName = StrApplName;
            inValue.Body.StrApplCode = StrApplCode;
            inValue.Body.StrEmailId = StrEmailId;
            return ((HAMARAORDER.ServiceReference1.WebServiceSoap)(this)).ForgetPasswordAsync(inValue);
        }
    }
}