﻿#pragma checksum "..\..\ManejoDeProveedores.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "41D4E1E056C3AD0A76E77B42823A1FAE66F52F6E6889E8B300D22A3D9192FD7F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MiPrimerCRUD;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MiPrimerCRUD {
    
    
    /// <summary>
    /// ManejoDeProveedores
    /// </summary>
    public partial class ManejoDeProveedores : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ManejoDeProveedores.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListaDeProveedores;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ManejoDeProveedores.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnInsertarProveedor;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ManejoDeProveedores.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBorrarProveedor;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ManejoDeProveedores.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtInsertarProveedor;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ManejoDeProveedores.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnActualizarProveedor;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ManejoDeProveedores.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtInsertarDireccionProveedor;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ManejoDeProveedores.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtInsertarTelefonoProveedor;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ManejoDeProveedores.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAyuda;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ManejoDeProveedores.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRegresarAlMenuProductos;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ManejoDeProveedores.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnGenerarReporteEnTexto;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MiPrimerCRUD;component/manejodeproveedores.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ManejoDeProveedores.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ListaDeProveedores = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.BtnInsertarProveedor = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\ManejoDeProveedores.xaml"
            this.BtnInsertarProveedor.Click += new System.Windows.RoutedEventHandler(this.BtnInsertarProveedor_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnBorrarProveedor = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\ManejoDeProveedores.xaml"
            this.BtnBorrarProveedor.Click += new System.Windows.RoutedEventHandler(this.BtnBorrarProveedor_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TxtInsertarProveedor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.BtnActualizarProveedor = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\ManejoDeProveedores.xaml"
            this.BtnActualizarProveedor.Click += new System.Windows.RoutedEventHandler(this.BtnActualizarProveedor_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TxtInsertarDireccionProveedor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TxtInsertarTelefonoProveedor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.BtnAyuda = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\ManejoDeProveedores.xaml"
            this.BtnAyuda.Click += new System.Windows.RoutedEventHandler(this.BtnAyuda_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BtnRegresarAlMenuProductos = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\ManejoDeProveedores.xaml"
            this.BtnRegresarAlMenuProductos.Click += new System.Windows.RoutedEventHandler(this.BtnRegresarAlMenuProductos_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnGenerarReporteEnTexto = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\ManejoDeProveedores.xaml"
            this.BtnGenerarReporteEnTexto.Click += new System.Windows.RoutedEventHandler(this.BtnGenerarReporteEnTexto_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

