﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Raiz.Deployment.ClientManager.DeployService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Version", Namespace="http://schemas.datacontract.org/2004/07/System")]
    [System.SerializableAttribute()]
    public partial class Version : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int _BuildField;
        
        private int _MajorField;
        
        private int _MinorField;
        
        private int _RevisionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int _Build {
            get {
                return this._BuildField;
            }
            set {
                if ((this._BuildField.Equals(value) != true)) {
                    this._BuildField = value;
                    this.RaisePropertyChanged("_Build");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int _Major {
            get {
                return this._MajorField;
            }
            set {
                if ((this._MajorField.Equals(value) != true)) {
                    this._MajorField = value;
                    this.RaisePropertyChanged("_Major");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int _Minor {
            get {
                return this._MinorField;
            }
            set {
                if ((this._MinorField.Equals(value) != true)) {
                    this._MinorField = value;
                    this.RaisePropertyChanged("_Minor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int _Revision {
            get {
                return this._RevisionField;
            }
            set {
                if ((this._RevisionField.Equals(value) != true)) {
                    this._RevisionField = value;
                    this.RaisePropertyChanged("_Revision");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DeployService.IDeployService", CallbackContract=typeof(Raiz.Deployment.ClientManager.DeployService.IDeployServiceCallback))]
    public interface IDeployService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/ConsultarPublicaciones", ReplyAction="http://tempuri.org/IDeployService/ConsultarPublicacionesResponse")]
        System.Collections.Generic.List<Raiz.Deployment.DTO.PubComponente> ConsultarPublicaciones();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/ConsultarPublicacionPorComponente", ReplyAction="http://tempuri.org/IDeployService/ConsultarPublicacionPorComponenteResponse")]
        Raiz.Deployment.DTO.PubComponente ConsultarPublicacionPorComponente(string componente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/RegistrarPublicacion", ReplyAction="http://tempuri.org/IDeployService/RegistrarPublicacionResponse")]
        void RegistrarPublicacion(Raiz.Deployment.DTO.PubComponente publicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/ListarSuscriptores", ReplyAction="http://tempuri.org/IDeployService/ListarSuscriptoresResponse")]
        System.Collections.Generic.List<Raiz.Deployment.DTO.Suscritor> ListarSuscriptores();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/Subscribe", ReplyAction="http://tempuri.org/IDeployService/SubscribeResponse")]
        System.Guid Subscribe(Raiz.Deployment.DTO.Suscritor suscrito);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeployService/Unsubscribe")]
        void Unsubscribe(System.Guid clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/Notificar", ReplyAction="http://tempuri.org/IDeployService/NotificarResponse")]
        void Notificar(System.Guid clientId, System.Collections.Generic.List<Raiz.Deployment.DTO.PubComponente> actualizaciones);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/NotificarUsuario", ReplyAction="http://tempuri.org/IDeployService/NotificarUsuarioResponse")]
        void NotificarUsuario(System.Guid idOrigen, System.Guid idDestino, System.Collections.Generic.List<Raiz.Deployment.DTO.PubComponente> actualizaciones);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/EnviarMensajeCliente", ReplyAction="http://tempuri.org/IDeployService/EnviarMensajeClienteResponse")]
        void EnviarMensajeCliente(System.Guid idOrigen, System.Guid idDestino, string mensaje, int msje);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/ForzarCierreAplicacionCliente", ReplyAction="http://tempuri.org/IDeployService/ForzarCierreAplicacionClienteResponse")]
        void ForzarCierreAplicacionCliente(System.Guid idOrigen, System.Guid idDestino, string mensaje);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/ListarVersionesInstaladasCliente", ReplyAction="http://tempuri.org/IDeployService/ListarVersionesInstaladasClienteResponse")]
        System.Collections.Generic.List<Raiz.Deployment.DTO.DescargaComponente> ListarVersionesInstaladasCliente(System.Guid idOrigen, System.Guid idDestino);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeployServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeployService/RecepcionarNotificacionMasiva")]
        void RecepcionarNotificacionMasiva(System.Collections.Generic.List<Raiz.Deployment.DTO.PubComponente> actualizaciones);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeployService/RecepcionarNotificacionPersonal")]
        void RecepcionarNotificacionPersonal(System.Collections.Generic.List<Raiz.Deployment.DTO.PubComponente> actualizaciones);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeployService/RecepcionarMensajePersonal")]
        void RecepcionarMensajePersonal(string mensaje, int msje);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeployService/ForzarCierreAplicacion")]
        void ForzarCierreAplicacion(string mensaje);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/VersionesInstaladasCliente", ReplyAction="http://tempuri.org/IDeployService/VersionesInstaladasClienteResponse")]
        System.Collections.Generic.List<Raiz.Deployment.DTO.DescargaComponente> VersionesInstaladasCliente();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeployServiceChannel : Raiz.Deployment.ClientManager.DeployService.IDeployService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeployServiceClient : System.ServiceModel.DuplexClientBase<Raiz.Deployment.ClientManager.DeployService.IDeployService>, Raiz.Deployment.ClientManager.DeployService.IDeployService {
        
        public DeployServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public DeployServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public DeployServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DeployServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DeployServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<Raiz.Deployment.DTO.PubComponente> ConsultarPublicaciones() {
            return base.Channel.ConsultarPublicaciones();
        }
        
        public Raiz.Deployment.DTO.PubComponente ConsultarPublicacionPorComponente(string componente) {
            return base.Channel.ConsultarPublicacionPorComponente(componente);
        }
        
        public void RegistrarPublicacion(Raiz.Deployment.DTO.PubComponente publicacion) {
            base.Channel.RegistrarPublicacion(publicacion);
        }
        
        public System.Collections.Generic.List<Raiz.Deployment.DTO.Suscritor> ListarSuscriptores() {
            return base.Channel.ListarSuscriptores();
        }
        
        public System.Guid Subscribe(Raiz.Deployment.DTO.Suscritor suscrito) {
            return base.Channel.Subscribe(suscrito);
        }
        
        public void Unsubscribe(System.Guid clientId) {
            base.Channel.Unsubscribe(clientId);
        }
        
        public void Notificar(System.Guid clientId, System.Collections.Generic.List<Raiz.Deployment.DTO.PubComponente> actualizaciones) {
            base.Channel.Notificar(clientId, actualizaciones);
        }
        
        public void NotificarUsuario(System.Guid idOrigen, System.Guid idDestino, System.Collections.Generic.List<Raiz.Deployment.DTO.PubComponente> actualizaciones) {
            base.Channel.NotificarUsuario(idOrigen, idDestino, actualizaciones);
        }
        
        public void EnviarMensajeCliente(System.Guid idOrigen, System.Guid idDestino, string mensaje, int msje) {
            base.Channel.EnviarMensajeCliente(idOrigen, idDestino, mensaje, msje);
        }
        
        public void ForzarCierreAplicacionCliente(System.Guid idOrigen, System.Guid idDestino, string mensaje) {
            base.Channel.ForzarCierreAplicacionCliente(idOrigen, idDestino, mensaje);
        }
        
        public System.Collections.Generic.List<Raiz.Deployment.DTO.DescargaComponente> ListarVersionesInstaladasCliente(System.Guid idOrigen, System.Guid idDestino) {
            return base.Channel.ListarVersionesInstaladasCliente(idOrigen, idDestino);
        }
    }
}
