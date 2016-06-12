namespace Nuits.HyperV.Switch.Model
{
    using System;
    using System.ComponentModel;
    using System.Management;
    using System.Collections;
    using System.Globalization;
    
    
    // 関数 ShouldSerialize<PropertyName> は、特定のプロパティをシリアル化する必要があるかどうかを調べるために VS プロパティ ブラウザで使用される関数です。これらの関数はすべての ValueType プロパティに追加されます ( NULL に設定できない型のプロパティ、Int32, BOOLなど)。これらの関数は Is<PropertyName>Null 関数を使用します。これらの関数はまた、プロパティの NULL 値を調べるプロパティのための TypeConverter 実装でも使用され、Visual studio でドラッグ アンド ドロップをする場合は、プロパティ ブラウザに空の値が表示されるようにします。
    // Functions Is<PropertyName>Null() は、プロパティが NULL かどうかを調べるために使用されます。
    // 関数 Reset<PropertyName> は Null 許容を使用できる読み込み/書き込みプロパティに追加されます。これらの関数は、プロパティを NULL に設定するためにプロパティ ブラウザの VS デザイナによって使用されます。
    // プロパティ用にクラスに追加されたすべてのプロパティは、Visual Studio デザイナ内での動作を定義するように、また使用する TypeConverter を定義するように設定されています。
    // WMI クラス用に生成された事前バインディング クラスです。BcdObject
    public class BcdObject : System.ComponentModel.Component {
        
        // クラスが存在する場所にWMI 名前空間を保持するプライベート プロパティです。
        private static string CreatedWmiNamespace = "root\\WMI";
        
        // このクラスを作成した WMI クラスの名前を保持するプライベート プロパティです。
        private static string CreatedClassName = "BcdObject";
        
        // さまざまなメソッドで使用される ManagementScope を保持するプライベート メンバ変数です。
        private static System.Management.ManagementScope statMgmtScope = null;
        
        private ManagementSystemProperties PrivateSystemProperties;
        
        // 基になる LateBound WMI オブジェクトです。
        private System.Management.ManagementObject PrivateLateBoundObject;
        
        // クラスの '自動コミット' 動作を保存するメンバ変数です。
        private bool AutoCommitProp;
        
        // インスタンスを表す埋め込みプロパティを保持するプライベート変数です。
        private System.Management.ManagementBaseObject embeddedObj;
        
        // 現在使用されている WMI オブジェクトです。
        private System.Management.ManagementBaseObject curObj;
        
        // インスタンスが埋め込みオブジェクトかどうかを示すフラグです。
        private bool isEmbedded;
        
        // 下記は WMI オブジェクトを使用してクラスのインスタンスを初期化するコンストラクタのオーバーロードです。
        public BcdObject() {
            this.InitializeObject(null, null, null);
        }
        
        public BcdObject(string keyId, string keyStoreFilePath) {
            this.InitializeObject(null, new System.Management.ManagementPath(BcdObject.ConstructPath(keyId, keyStoreFilePath)), null);
        }
        
        public BcdObject(System.Management.ManagementScope mgmtScope, string keyId, string keyStoreFilePath) {
            this.InitializeObject(((System.Management.ManagementScope)(mgmtScope)), new System.Management.ManagementPath(BcdObject.ConstructPath(keyId, keyStoreFilePath)), null);
        }
        
        public BcdObject(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(null, path, getOptions);
        }
        
        public BcdObject(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path) {
            this.InitializeObject(mgmtScope, path, null);
        }
        
        public BcdObject(System.Management.ManagementPath path) {
            this.InitializeObject(null, path, null);
        }
        
        public BcdObject(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(mgmtScope, path, getOptions);
        }
        
        public BcdObject(System.Management.ManagementObject theObject) {
            Initialize();
            if ((CheckIfProperClass(theObject) == true)) {
                PrivateLateBoundObject = theObject;
                PrivateSystemProperties = new ManagementSystemProperties(PrivateLateBoundObject);
                curObj = PrivateLateBoundObject;
            }
            else {
                throw new System.ArgumentException("クラス名が一致しません。");
            }
        }
        
        public BcdObject(System.Management.ManagementBaseObject theObject) {
            Initialize();
            if ((CheckIfProperClass(theObject) == true)) {
                embeddedObj = theObject;
                PrivateSystemProperties = new ManagementSystemProperties(theObject);
                curObj = embeddedObj;
                isEmbedded = true;
            }
            else {
                throw new System.ArgumentException("クラス名が一致しません。");
            }
        }
        
        // WMI クラスの名前空間を返すプロパティです。
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OriginatingNamespace {
            get {
                return "root\\WMI";
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ManagementClassName {
            get {
                string strRet = CreatedClassName;
                if ((curObj != null)) {
                    if ((curObj.ClassPath != null)) {
                        strRet = ((string)(curObj["__CLASS"]));
                        if (((strRet == null) 
                                    || (strRet == string.Empty))) {
                            strRet = CreatedClassName;
                        }
                    }
                }
                return strRet;
            }
        }
        
        // WMI オブジェクトのシステム プロパティを取得するための埋め込みオブジェクトをポイントするプロパティです。
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ManagementSystemProperties SystemProperties {
            get {
                return PrivateSystemProperties;
            }
        }
        
        // 基になる LateBound WMI オブジェクトを返すプロパティです。
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Management.ManagementBaseObject LateBoundObject {
            get {
                return curObj;
            }
        }
        
        // オブジェクトの ManagementScope です。
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Management.ManagementScope Scope {
            get {
                if ((isEmbedded == false)) {
                    return PrivateLateBoundObject.Scope;
                }
                else {
                    return null;
                }
            }
            set {
                if ((isEmbedded == false)) {
                    PrivateLateBoundObject.Scope = value;
                }
            }
        }
        
        // WMI オブジェクトのコミット動作を表示するプロパティです。 これが true の場合、プロパティが変更するたびに WMI オブジェクトは自動的に保存されます (すなわち、プロパティを変更した後で Put() が呼び出されます)。
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AutoCommit {
            get {
                return AutoCommitProp;
            }
            set {
                AutoCommitProp = value;
            }
        }
        
        // 基になる WMI オブジェクトの ManagementPath です。
        [Browsable(true)]
        public System.Management.ManagementPath Path {
            get {
                if ((isEmbedded == false)) {
                    return PrivateLateBoundObject.Path;
                }
                else {
                    return null;
                }
            }
            set {
                if ((isEmbedded == false)) {
                    if ((CheckIfProperClass(null, value, null) != true)) {
                        throw new System.ArgumentException("クラス名が一致しません。");
                    }
                    PrivateLateBoundObject.Path = value;
                }
            }
        }
        
        // さまざまなメソッドで使用されるプライベート スタティック スコープ プロパティです。
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static System.Management.ManagementScope StaticScope {
            get {
                return statMgmtScope;
            }
            set {
                statMgmtScope = value;
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("This is the guid id of this object, unique to this store.")]
        public string Id {
            get {
                return ((string)(curObj["Id"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("This is the file path of the store that this object belongs to.")]
        public string StoreFilePath {
            get {
                return ((string)(curObj["StoreFilePath"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsTypeNull {
            get {
                if ((curObj["Type"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The upper 4 bits (28-31) represent the object type. The meaning of the lower 28 b" +
            "its (0-27) is dependent on the object type.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint Type {
            get {
                if ((curObj["Type"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["Type"]));
            }
        }
        
        private bool CheckIfProperClass(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions OptionsParam) {
            if (((path != null) 
                        && (string.Compare(path.ClassName, this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0))) {
                return true;
            }
            else {
                return CheckIfProperClass(new System.Management.ManagementObject(mgmtScope, path, OptionsParam));
            }
        }
        
        private bool CheckIfProperClass(System.Management.ManagementBaseObject theObj) {
            if (((theObj != null) 
                        && (string.Compare(((string)(theObj["__CLASS"])), this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0))) {
                return true;
            }
            else {
                System.Array parentClasses = ((System.Array)(theObj["__DERIVATION"]));
                if ((parentClasses != null)) {
                    int count = 0;
                    for (count = 0; (count < parentClasses.Length); count = (count + 1)) {
                        if ((string.Compare(((string)(parentClasses.GetValue(count))), this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0)) {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        private bool ShouldSerializeType() {
            if ((this.IsTypeNull == false)) {
                return true;
            }
            return false;
        }
        
        [Browsable(true)]
        public void CommitObject() {
            if ((isEmbedded == false)) {
                PrivateLateBoundObject.Put();
            }
        }
        
        [Browsable(true)]
        public void CommitObject(System.Management.PutOptions putOptions) {
            if ((isEmbedded == false)) {
                PrivateLateBoundObject.Put(putOptions);
            }
        }
        
        private void Initialize() {
            AutoCommitProp = true;
            isEmbedded = false;
        }
        
        private static string ConstructPath(string keyId, string keyStoreFilePath) {
            string strPath = "root\\WMI:BcdObject";
            strPath = string.Concat(strPath, string.Concat(".Id=", string.Concat("\"", string.Concat(keyId, "\""))));
            strPath = string.Concat(strPath, string.Concat(",StoreFilePath=", string.Concat("\"", string.Concat(keyStoreFilePath, "\""))));
            return strPath;
        }
        
        private void InitializeObject(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            Initialize();
            if ((path != null)) {
                if ((CheckIfProperClass(mgmtScope, path, getOptions) != true)) {
                    throw new System.ArgumentException("クラス名が一致しません。");
                }
            }
            PrivateLateBoundObject = new System.Management.ManagementObject(mgmtScope, path, getOptions);
            PrivateSystemProperties = new ManagementSystemProperties(PrivateLateBoundObject);
            curObj = PrivateLateBoundObject;
        }
        
        // WMI クラスのインスタンスを列挙する GetInstances() ヘルプのオーバーロードです。
        public static BcdObjectCollection GetInstances() {
            return GetInstances(null, null, null);
        }
        
        public static BcdObjectCollection GetInstances(string condition) {
            return GetInstances(null, condition, null);
        }
        
        public static BcdObjectCollection GetInstances(string[] selectedProperties) {
            return GetInstances(null, null, selectedProperties);
        }
        
        public static BcdObjectCollection GetInstances(string condition, string[] selectedProperties) {
            return GetInstances(null, condition, selectedProperties);
        }
        
        public static BcdObjectCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\WMI";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementPath pathObj = new System.Management.ManagementPath();
            pathObj.ClassName = "BcdObject";
            pathObj.NamespacePath = "root\\WMI";
            System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
            if ((enumOptions == null)) {
                enumOptions = new System.Management.EnumerationOptions();
                enumOptions.EnsureLocatable = true;
            }
            return new BcdObjectCollection(clsObject.GetInstances(enumOptions));
        }
        
        public static BcdObjectCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition) {
            return GetInstances(mgmtScope, condition, null);
        }
        
        public static BcdObjectCollection GetInstances(System.Management.ManagementScope mgmtScope, string[] selectedProperties) {
            return GetInstances(mgmtScope, null, selectedProperties);
        }
        
        public static BcdObjectCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, string[] selectedProperties) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\WMI";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("BcdObject", condition, selectedProperties));
            System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
            enumOptions.EnsureLocatable = true;
            ObjectSearcher.Options = enumOptions;
            return new BcdObjectCollection(ObjectSearcher.Get());
        }
        
        [Browsable(true)]
        public static BcdObject CreateInstance() {
            System.Management.ManagementScope mgmtScope = null;
            if ((statMgmtScope == null)) {
                mgmtScope = new System.Management.ManagementScope();
                mgmtScope.Path.NamespacePath = CreatedWmiNamespace;
            }
            else {
                mgmtScope = statMgmtScope;
            }
            System.Management.ManagementPath mgmtPath = new System.Management.ManagementPath(CreatedClassName);
            System.Management.ManagementClass tmpMgmtClass = new System.Management.ManagementClass(mgmtScope, mgmtPath, null);
            return new BcdObject(tmpMgmtClass.CreateInstance());
        }
        
        [Browsable(true)]
        public void Delete() {
            PrivateLateBoundObject.Delete();
        }
        
        public bool DeleteElement(uint Type) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("DeleteElement");
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("DeleteElement", inParams, null);
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool EnumerateElements(out System.Management.ManagementBaseObject[] Elements) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("EnumerateElements", inParams, null);
                Elements = ((System.Management.ManagementBaseObject[])(outParams.Properties["Elements"].Value));
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                Elements = null;
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool EnumerateElementTypes(out uint[] Types) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("EnumerateElementTypes", inParams, null);
                Types = ((uint[])(outParams.Properties["Types"].Value));
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                Types = null;
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool GetElement(uint Type, out System.Management.ManagementBaseObject Element) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("GetElement");
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("GetElement", inParams, null);
                Element = ((System.Management.ManagementBaseObject)(outParams.Properties["Element"].Value));
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                Element = null;
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool GetElementWithFlags(uint Flags, uint Type, out System.Management.ManagementBaseObject Element) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("GetElementWithFlags");
                inParams["Flags"] = ((uint)(Flags));
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("GetElementWithFlags", inParams, null);
                Element = ((System.Management.ManagementBaseObject)(outParams.Properties["Element"].Value));
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                Element = null;
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool SetBooleanElement(bool Boolean, uint Type) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetBooleanElement");
                inParams["Boolean"] = ((bool)(Boolean));
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetBooleanElement", inParams, null);
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool SetDeviceElement(string AdditionalOptions, uint DeviceType, uint Type) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetDeviceElement");
                inParams["AdditionalOptions"] = ((string)(AdditionalOptions));
                inParams["DeviceType"] = ((uint)(DeviceType));
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetDeviceElement", inParams, null);
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool SetFileDeviceElement(string AdditionalOptions, uint DeviceType, string ParentAdditionalOptions, uint ParentDeviceType, string ParentPath, string Path, uint Type) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetFileDeviceElement");
                inParams["AdditionalOptions"] = ((string)(AdditionalOptions));
                inParams["DeviceType"] = ((uint)(DeviceType));
                inParams["ParentAdditionalOptions"] = ((string)(ParentAdditionalOptions));
                inParams["ParentDeviceType"] = ((uint)(ParentDeviceType));
                inParams["ParentPath"] = ((string)(ParentPath));
                inParams["Path"] = ((string)(Path));
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetFileDeviceElement", inParams, null);
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool SetIntegerElement(ulong Integer, uint Type) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetIntegerElement");
                inParams["Integer"] = ((ulong)(Integer));
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetIntegerElement", inParams, null);
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool SetIntegerListElement(ulong[] Integers, uint Type) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetIntegerListElement");
                inParams["Integers"] = ((ulong[])(Integers));
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetIntegerListElement", inParams, null);
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool SetObjectElement(string Id, uint Type) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetObjectElement");
                inParams["Id"] = ((string)(Id));
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetObjectElement", inParams, null);
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool SetObjectListElement(string[] Ids, uint Type) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetObjectListElement");
                inParams["Ids"] = ((string[])(Ids));
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetObjectListElement", inParams, null);
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool SetPartitionDeviceElement(string AdditionalOptions, uint DeviceType, string Path, uint Type) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetPartitionDeviceElement");
                inParams["AdditionalOptions"] = ((string)(AdditionalOptions));
                inParams["DeviceType"] = ((uint)(DeviceType));
                inParams["Path"] = ((string)(Path));
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetPartitionDeviceElement", inParams, null);
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool SetPartitionDeviceElementWithFlags(string AdditionalOptions, uint DeviceType, uint Flags, string Path, uint Type) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetPartitionDeviceElementWithFlags");
                inParams["AdditionalOptions"] = ((string)(AdditionalOptions));
                inParams["DeviceType"] = ((uint)(DeviceType));
                inParams["Flags"] = ((uint)(Flags));
                inParams["Path"] = ((string)(Path));
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetPartitionDeviceElementWithFlags", inParams, null);
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool SetQualifiedPartitionDeviceElement(string DiskSignature, string PartitionIdentifier, uint PartitionStyle, uint Type) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetQualifiedPartitionDeviceElement");
                inParams["DiskSignature"] = ((string)(DiskSignature));
                inParams["PartitionIdentifier"] = ((string)(PartitionIdentifier));
                inParams["PartitionStyle"] = ((uint)(PartitionStyle));
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetQualifiedPartitionDeviceElement", inParams, null);
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool SetStringElement(string String, uint Type) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetStringElement");
                inParams["String"] = ((string)(String));
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetStringElement", inParams, null);
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToBoolean(0);
            }
        }
        
        public bool SetVhdDeviceElement(uint CustomLocate, string ParentAdditionalOptions, uint ParentDeviceType, string ParentPath, string Path, uint Type) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetVhdDeviceElement");
                inParams["CustomLocate"] = ((uint)(CustomLocate));
                inParams["ParentAdditionalOptions"] = ((string)(ParentAdditionalOptions));
                inParams["ParentDeviceType"] = ((uint)(ParentDeviceType));
                inParams["ParentPath"] = ((string)(ParentPath));
                inParams["Path"] = ((string)(Path));
                inParams["Type"] = ((uint)(Type));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetVhdDeviceElement", inParams, null);
                return System.Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToBoolean(0);
            }
        }
        
        // クラスのインスタンスを列挙する列挙子の実装です。
        public class BcdObjectCollection : object, ICollection {
            
            private ManagementObjectCollection privColObj;
            
            public BcdObjectCollection(ManagementObjectCollection objCollection) {
                privColObj = objCollection;
            }
            
            public virtual int Count {
                get {
                    return privColObj.Count;
                }
            }
            
            public virtual bool IsSynchronized {
                get {
                    return privColObj.IsSynchronized;
                }
            }
            
            public virtual object SyncRoot {
                get {
                    return this;
                }
            }
            
            public virtual void CopyTo(System.Array array, int index) {
                privColObj.CopyTo(array, index);
                int nCtr;
                for (nCtr = 0; (nCtr < array.Length); nCtr = (nCtr + 1)) {
                    array.SetValue(new BcdObject(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
                }
            }
            
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return new BcdObjectEnumerator(privColObj.GetEnumerator());
            }
            
            public class BcdObjectEnumerator : object, System.Collections.IEnumerator {
                
                private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
                
                public BcdObjectEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                    privObjEnum = objEnum;
                }
                
                public virtual object Current {
                    get {
                        return new BcdObject(((System.Management.ManagementObject)(privObjEnum.Current)));
                    }
                }
                
                public virtual bool MoveNext() {
                    return privObjEnum.MoveNext();
                }
                
                public virtual void Reset() {
                    privObjEnum.Reset();
                }
            }
        }
        
        // ValueType プロパティの NULL 値を扱う TypeConverter です。
        public class WMIValueTypeConverter : TypeConverter {
            
            private TypeConverter baseConverter;
            
            private System.Type baseType;
            
            public WMIValueTypeConverter(System.Type inBaseType) {
                baseConverter = TypeDescriptor.GetConverter(inBaseType);
                baseType = inBaseType;
            }
            
            public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type srcType) {
                return baseConverter.CanConvertFrom(context, srcType);
            }
            
            public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) {
                return baseConverter.CanConvertTo(context, destinationType);
            }
            
            public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) {
                return baseConverter.ConvertFrom(context, culture, value);
            }
            
            public override object CreateInstance(System.ComponentModel.ITypeDescriptorContext context, System.Collections.IDictionary dictionary) {
                return baseConverter.CreateInstance(context, dictionary);
            }
            
            public override bool GetCreateInstanceSupported(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetCreateInstanceSupported(context);
            }
            
            public override PropertyDescriptorCollection GetProperties(System.ComponentModel.ITypeDescriptorContext context, object value, System.Attribute[] attributeVar) {
                return baseConverter.GetProperties(context, value, attributeVar);
            }
            
            public override bool GetPropertiesSupported(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetPropertiesSupported(context);
            }
            
            public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetStandardValues(context);
            }
            
            public override bool GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetStandardValuesExclusive(context);
            }
            
            public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetStandardValuesSupported(context);
            }
            
            public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) {
                if ((baseType.BaseType == typeof(System.Enum))) {
                    if ((value.GetType() == destinationType)) {
                        return value;
                    }
                    if ((((value == null) 
                                && (context != null)) 
                                && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
                        return  "NULL_ENUM_VALUE" ;
                    }
                    return baseConverter.ConvertTo(context, culture, value, destinationType);
                }
                if (((baseType == typeof(bool)) 
                            && (baseType.BaseType == typeof(System.ValueType)))) {
                    if ((((value == null) 
                                && (context != null)) 
                                && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
                        return "";
                    }
                    return baseConverter.ConvertTo(context, culture, value, destinationType);
                }
                if (((context != null) 
                            && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
                    return "";
                }
                return baseConverter.ConvertTo(context, culture, value, destinationType);
            }
        }
        
        // WMI システム プロパティを表す埋め込みクラスです。
        [TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
        public class ManagementSystemProperties {
            
            private System.Management.ManagementBaseObject PrivateLateBoundObject;
            
            public ManagementSystemProperties(System.Management.ManagementBaseObject ManagedObject) {
                PrivateLateBoundObject = ManagedObject;
            }
            
            [Browsable(true)]
            public int GENUS {
                get {
                    return ((int)(PrivateLateBoundObject["__GENUS"]));
                }
            }
            
            [Browsable(true)]
            public string CLASS {
                get {
                    return ((string)(PrivateLateBoundObject["__CLASS"]));
                }
            }
            
            [Browsable(true)]
            public string SUPERCLASS {
                get {
                    return ((string)(PrivateLateBoundObject["__SUPERCLASS"]));
                }
            }
            
            [Browsable(true)]
            public string DYNASTY {
                get {
                    return ((string)(PrivateLateBoundObject["__DYNASTY"]));
                }
            }
            
            [Browsable(true)]
            public string RELPATH {
                get {
                    return ((string)(PrivateLateBoundObject["__RELPATH"]));
                }
            }
            
            [Browsable(true)]
            public int PROPERTY_COUNT {
                get {
                    return ((int)(PrivateLateBoundObject["__PROPERTY_COUNT"]));
                }
            }
            
            [Browsable(true)]
            public string[] DERIVATION {
                get {
                    return ((string[])(PrivateLateBoundObject["__DERIVATION"]));
                }
            }
            
            [Browsable(true)]
            public string SERVER {
                get {
                    return ((string)(PrivateLateBoundObject["__SERVER"]));
                }
            }
            
            [Browsable(true)]
            public string NAMESPACE {
                get {
                    return ((string)(PrivateLateBoundObject["__NAMESPACE"]));
                }
            }
            
            [Browsable(true)]
            public string PATH {
                get {
                    return ((string)(PrivateLateBoundObject["__PATH"]));
                }
            }
        }
    }
}
