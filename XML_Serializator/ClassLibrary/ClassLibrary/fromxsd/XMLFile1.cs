﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 
namespace Library {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://example.org/jk/pastures")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://example.org/jk/pastures", IsNullable=false)]
    public partial class pastures {
        
        private pasturesMeeting[] meetingsField;
        
        private object[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("meeting", IsNullable=false)]
        public pasturesMeeting[] meetings {
            get {
                return this.meetingsField;
            }
            set {
                this.meetingsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("centaur", typeof(pasturesCentaur))]
        [System.Xml.Serialization.XmlElementAttribute("minotaur", typeof(pasturesMinotaur))]
        [System.Xml.Serialization.XmlElementAttribute("pasture", typeof(pasturesPasture))]
        public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://example.org/jk/pastures")]
    public partial class pasturesMeeting {
        
        private int[][] participantsField;
        
        private string locationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("participant", typeof(int), IsNullable=false)]
        public int[][] participants {
            get {
                return this.participantsField;
            }
            set {
                this.participantsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://example.org/jk/pastures")]
    public partial class pasturesCentaur {
        
        private object beardField;
        
        private object mustacheField;
        
        private object whiskersField;
        
        private string nameField;
        
        private int ageField;
        
        private bool ageFieldSpecified;
        
        private int idField;
        
        /// <remarks/>
        public object beard {
            get {
                return this.beardField;
            }
            set {
                this.beardField = value;
            }
        }
        
        /// <remarks/>
        public object mustache {
            get {
                return this.mustacheField;
            }
            set {
                this.mustacheField = value;
            }
        }
        
        /// <remarks/>
        public object whiskers {
            get {
                return this.whiskersField;
            }
            set {
                this.whiskersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int age {
            get {
                return this.ageField;
            }
            set {
                this.ageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ageSpecified {
            get {
                return this.ageFieldSpecified;
            }
            set {
                this.ageFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://example.org/jk/pastures")]
    public partial class pasturesMinotaur {
        
        private string nameField;
        
        private int ageField;
        
        private bool ageFieldSpecified;
        
        private int idField;
        
        private double massField;
        
        private bool massFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int age {
            get {
                return this.ageField;
            }
            set {
                this.ageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ageSpecified {
            get {
                return this.ageFieldSpecified;
            }
            set {
                this.ageFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double mass {
            get {
                return this.massField;
            }
            set {
                this.massField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool massSpecified {
            get {
                return this.massFieldSpecified;
            }
            set {
                this.massFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://example.org/jk/pastures")]
    public partial class pasturesPasture {
        
        private string[] nameField;
        
        private double areaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("name")]
        public string[] name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double area {
            get {
                return this.areaField;
            }
            set {
                this.areaField = value;
            }
        }
    }
}
