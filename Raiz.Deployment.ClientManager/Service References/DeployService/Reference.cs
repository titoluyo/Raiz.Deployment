﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Raiz.Deployment.ClientManager.DeployService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DeployService.IDeployService", CallbackContract=typeof(Raiz.Deployment.ClientManager.DeployService.IDeployServiceCallback))]
    public interface IDeployService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/ConsultarPublicaciones", ReplyAction="http://tempuri.org/IDeployService/ConsultarPublicacionesResponse")]
        System.Collections.Generic.List<Raiz.Deployment.DTO.PubComponente> ConsultarPublicaciones();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/ConsultarPublicacionPorComponente", ReplyAction="http://tempuri.org/IDeployService/ConsultarPublicacionPorComponenteResponse")]
        Raiz.Deployment.DTO.PubComponente ConsultarPublicacionPorComponente(string componente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/Subscribe", ReplyAction="http://tempuri.org/IDeployService/SubscribeResponse")]
        System.Guid Subscribe();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeployService/Unsubscribe")]
        void Unsubscribe(System.Guid clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeployService/Notificar", ReplyAction="http://tempuri.org/IDeployService/NotificarResponse")]
        void Notificar(System.Guid clientId, Raiz.Deployment.DTO.PubComponente actualizacion);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeployServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDeployService/RecepcionarNotificacion")]
        void RecepcionarNotificacion(Raiz.Deployment.DTO.PubComponente actualizacion);
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
        
        public System.Guid Subscribe() {
            return base.Channel.Subscribe();
        }
        
        public void Unsubscribe(System.Guid clientId) {
            base.Channel.Unsubscribe(clientId);
        }
        
        public void Notificar(System.Guid clientId, Raiz.Deployment.DTO.PubComponente actualizacion) {
            base.Channel.Notificar(clientId, actualizacion);
        }
    }
}