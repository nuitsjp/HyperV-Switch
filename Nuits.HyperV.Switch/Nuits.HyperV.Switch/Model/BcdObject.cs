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
    public class BcdObject : Component {
        
        // クラスが存在する場所にWMI 名前空間を保持するプライベート プロパティです。
        private static readonly string CreatedWmiNamespace = "root\\WMI";
        
        // このクラスを作成した WMI クラスの名前を保持するプライベート プロパティです。
        private static readonly string CreatedClassName = "BcdObject";
        
        // さまざまなメソッドで使用される ManagementScope を保持するプライベート メンバ変数です。
        private static ManagementScope _statMgmtScope;
        
        private ManagementSystemProperties _privateSystemProperties;
        
        // 基になる LateBound WMI オブジェクトです。
        private ManagementObject _privateLateBoundObject;
        
        // クラスの '自動コミット' 動作を保存するメンバ変数です。
        private bool _autoCommitProp;
        
        // 現在使用されている WMI オブジェクトです。
        private ManagementBaseObject _curObj;
        
        // インスタンスが埋め込みオブジェクトかどうかを示すフラグです。
        private bool _isEmbedded;
        
        // 下記は WMI オブジェクトを使用してクラスのインスタンスを初期化するコンストラクタのオーバーロードです。
        public BcdObject() {
            InitializeObject(null, null, null);
        }
        
        public BcdObject(string keyId, string keyStoreFilePath) {
            InitializeObject(null, new ManagementPath(ConstructPath(keyId, keyStoreFilePath)), null);
        }
        
        public BcdObject(ManagementScope mgmtScope, string keyId, string keyStoreFilePath) {
            InitializeObject(mgmtScope, new ManagementPath(ConstructPath(keyId, keyStoreFilePath)), null);
        }
        
        public BcdObject(ManagementPath path, ObjectGetOptions getOptions) {
            InitializeObject(null, path, getOptions);
        }
        
        public BcdObject(ManagementScope mgmtScope, ManagementPath path) {
            InitializeObject(mgmtScope, path, null);
        }
        
        public BcdObject(ManagementPath path) {
            InitializeObject(null, path, null);
        }
        
        public BcdObject(ManagementScope mgmtScope, ManagementPath path, ObjectGetOptions getOptions) {
            InitializeObject(mgmtScope, path, getOptions);
        }
        
        public BcdObject(ManagementObject theObject) {
            Initialize();
            if (CheckIfProperClass(theObject)) {
                _privateLateBoundObject = theObject;
                _privateSystemProperties = new ManagementSystemProperties(_privateLateBoundObject);
                _curObj = _privateLateBoundObject;
            }
            else {
                throw new ArgumentException("クラス名が一致しません。");
            }
        }
        
        public BcdObject(ManagementBaseObject theObject) {
            Initialize();
            if (CheckIfProperClass(theObject)) {
                _privateSystemProperties = new ManagementSystemProperties(theObject);
                _curObj = theObject;
                _isEmbedded = true;
            }
            else {
                throw new ArgumentException("クラス名が一致しません。");
            }
        }
        
        // WMI クラスの名前空間を返すプロパティです。
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OriginatingNamespace => "root\\WMI";

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ManagementClassName {
            get {
                var strRet = CreatedClassName;
                if (_curObj?.ClassPath != null) {
                    strRet = (string)_curObj["__CLASS"];
                    if ((strRet == null) 
                        || (strRet == string.Empty)) {
                             strRet = CreatedClassName;
                         }
                }
                return strRet;
            }
        }
        
        // WMI オブジェクトのシステム プロパティを取得するための埋め込みオブジェクトをポイントするプロパティです。
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ManagementSystemProperties SystemProperties => _privateSystemProperties;

        // 基になる LateBound WMI オブジェクトを返すプロパティです。
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ManagementBaseObject LateBoundObject => _curObj;

        // オブジェクトの ManagementScope です。
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ManagementScope Scope {
            get {
                if (_isEmbedded == false) {
                    return _privateLateBoundObject.Scope;
                }
                else {
                    return null;
                }
            }
            set {
                if (_isEmbedded == false) {
                    _privateLateBoundObject.Scope = value;
                }
            }
        }
        
        // WMI オブジェクトのコミット動作を表示するプロパティです。 これが true の場合、プロパティが変更するたびに WMI オブジェクトは自動的に保存されます (すなわち、プロパティを変更した後で Put() が呼び出されます)。
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AutoCommit {
            get {
                return _autoCommitProp;
            }
            set {
                _autoCommitProp = value;
            }
        }
        
        // 基になる WMI オブジェクトの ManagementPath です。
        [Browsable(true)]
        public ManagementPath Path {
            get {
                if (_isEmbedded == false) {
                    return _privateLateBoundObject.Path;
                }
                else {
                    return null;
                }
            }
            set {
                if (_isEmbedded == false) {
                    if (CheckIfProperClass(null, value, null) != true) {
                        throw new ArgumentException("クラス名が一致しません。");
                    }
                    _privateLateBoundObject.Path = value;
                }
            }
        }
        
        // さまざまなメソッドで使用されるプライベート スタティック スコープ プロパティです。
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static ManagementScope StaticScope {
            get {
                return _statMgmtScope;
            }
            set {
                _statMgmtScope = value;
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("This is the guid id of this object, unique to this store.")]
        public string Id => (string)_curObj["Id"];

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("This is the file path of the store that this object belongs to.")]
        public string StoreFilePath => (string)_curObj["StoreFilePath"];

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsTypeNull {
            get {
                if (_curObj["Type"] == null) {
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
        [TypeConverter(typeof(WmiValueTypeConverter))]
        public uint Type {
            get {
                if (_curObj["Type"] == null) {
                    return Convert.ToUInt32(0);
                }
                return (uint)_curObj["Type"];
            }
        }
        
        private bool CheckIfProperClass(ManagementScope mgmtScope, ManagementPath path, ObjectGetOptions optionsParam) {
            if ((path != null) 
                && (string.Compare(path.ClassName, ManagementClassName, true, CultureInfo.InvariantCulture) == 0)) {
                return true;
            }
            else {
                return CheckIfProperClass(new ManagementObject(mgmtScope, path, optionsParam));
            }
        }
        
        private bool CheckIfProperClass(ManagementBaseObject theObj) {
            if ((theObj != null) 
                && (string.Compare((string)theObj["__CLASS"], ManagementClassName, true, CultureInfo.InvariantCulture) == 0)) {
                return true;
            }
            else {
                // ReSharper disable once PossibleNullReferenceException
                var parentClasses = (Array)theObj["__DERIVATION"];
                if (parentClasses != null) {
                    for (var count = 0; count < parentClasses.Length; count = count + 1) {
                        if (string.Compare((string)parentClasses.GetValue(count), ManagementClassName, true, CultureInfo.InvariantCulture) == 0) {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        private bool ShouldSerializeType() {
            if (IsTypeNull == false) {
                return true;
            }
            return false;
        }
        
        [Browsable(true)]
        public void CommitObject() {
            if (_isEmbedded == false) {
                _privateLateBoundObject.Put();
            }
        }
        
        [Browsable(true)]
        public void CommitObject(PutOptions putOptions) {
            if (_isEmbedded == false) {
                _privateLateBoundObject.Put(putOptions);
            }
        }
        
        private void Initialize() {
            _autoCommitProp = true;
            _isEmbedded = false;
        }
        
        private static string ConstructPath(string keyId, string keyStoreFilePath) {
            var strPath = "root\\WMI:BcdObject";
            strPath = string.Concat(strPath, string.Concat(".Id=", string.Concat("\"", string.Concat(keyId, "\""))));
            strPath = string.Concat(strPath, string.Concat(",StoreFilePath=", string.Concat("\"", string.Concat(keyStoreFilePath, "\""))));
            return strPath;
        }
        
        private void InitializeObject(ManagementScope mgmtScope, ManagementPath path, ObjectGetOptions getOptions) {
            Initialize();
            if (path != null) {
                if (CheckIfProperClass(mgmtScope, path, getOptions) != true) {
                    throw new ArgumentException("クラス名が一致しません。");
                }
            }
            _privateLateBoundObject = new ManagementObject(mgmtScope, path, getOptions);
            _privateSystemProperties = new ManagementSystemProperties(_privateLateBoundObject);
            _curObj = _privateLateBoundObject;
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
        
        public static BcdObjectCollection GetInstances(ManagementScope mgmtScope, EnumerationOptions enumOptions) {
            if (mgmtScope == null) {
                mgmtScope = _statMgmtScope ?? new ManagementScope {Path = {NamespacePath = "root\\WMI"}};
            }
            var pathObj = new ManagementPath
            {
                ClassName = "BcdObject",
                NamespacePath = "root\\WMI"
            };
            var clsObject = new ManagementClass(mgmtScope, pathObj, null);
            if (enumOptions == null) {
                enumOptions = new EnumerationOptions {EnsureLocatable = true};
            }
            return new BcdObjectCollection(clsObject.GetInstances(enumOptions));
        }
        
        public static BcdObjectCollection GetInstances(ManagementScope mgmtScope, string condition) {
            return GetInstances(mgmtScope, condition, null);
        }
        
        public static BcdObjectCollection GetInstances(ManagementScope mgmtScope, string[] selectedProperties) {
            return GetInstances(mgmtScope, null, selectedProperties);
        }
        
        public static BcdObjectCollection GetInstances(ManagementScope mgmtScope, string condition, string[] selectedProperties) {
            if (mgmtScope == null) {
                mgmtScope = _statMgmtScope ?? new ManagementScope {Path = {NamespacePath = "root\\WMI"}};
            }
            var objectSearcher = new ManagementObjectSearcher(mgmtScope, new SelectQuery("BcdObject", condition, selectedProperties));
            var enumOptions = new EnumerationOptions {EnsureLocatable = true};
            objectSearcher.Options = enumOptions;
            return new BcdObjectCollection(objectSearcher.Get());
        }
        
        [Browsable(true)]
        public static BcdObject CreateInstance() {
            var mgmtScope = _statMgmtScope ?? new ManagementScope {Path = {NamespacePath = CreatedWmiNamespace}};
            var mgmtPath = new ManagementPath(CreatedClassName);
            var tmpMgmtClass = new ManagementClass(mgmtScope, mgmtPath, null);
            return new BcdObject(tmpMgmtClass.CreateInstance());
        }
        
        [Browsable(true)]
        public void Delete() {
            _privateLateBoundObject.Delete();
        }
        
        public bool DeleteElement(uint type) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("DeleteElement");
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("DeleteElement", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return Convert.ToBoolean(0);
            }
        }
        
        public bool EnumerateElements(out ManagementBaseObject[] elements) {
            if (_isEmbedded == false) {
                var outParams = _privateLateBoundObject.InvokeMethod("EnumerateElements", null, null);
                // ReSharper disable once PossibleNullReferenceException
                elements = (ManagementBaseObject[])outParams.Properties["Elements"].Value;
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                elements = null;
                return Convert.ToBoolean(0);
            }
        }
        
        public bool EnumerateElementTypes(out uint[] types) {
            if (_isEmbedded == false) {
                var outParams = _privateLateBoundObject.InvokeMethod("EnumerateElementTypes", null, null);
                // ReSharper disable once PossibleNullReferenceException
                types = (uint[])outParams.Properties["Types"].Value;
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                types = null;
                return Convert.ToBoolean(0);
            }
        }
        
        public bool GetElement(uint type, out ManagementBaseObject element) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("GetElement");
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("GetElement", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                element = (ManagementBaseObject)outParams.Properties["Element"].Value;
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                element = null;
                return Convert.ToBoolean(0);
            }
        }
        
        public bool GetElementWithFlags(uint flags, uint type, out ManagementBaseObject element) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("GetElementWithFlags");
                inParams["Flags"] = flags;
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("GetElementWithFlags", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                element = (ManagementBaseObject)outParams.Properties["Element"].Value;
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                element = null;
                return Convert.ToBoolean(0);
            }
        }
        
        public bool SetBooleanElement(bool boolean, uint type) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("SetBooleanElement");
                inParams["Boolean"] = boolean;
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("SetBooleanElement", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return Convert.ToBoolean(0);
            }
        }
        
        public bool SetDeviceElement(string additionalOptions, uint deviceType, uint type) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("SetDeviceElement");
                inParams["AdditionalOptions"] = additionalOptions;
                inParams["DeviceType"] = deviceType;
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("SetDeviceElement", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return Convert.ToBoolean(0);
            }
        }
        
        public bool SetFileDeviceElement(string additionalOptions, uint deviceType, string parentAdditionalOptions, uint parentDeviceType, string parentPath, string path, uint type) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("SetFileDeviceElement");
                inParams["AdditionalOptions"] = additionalOptions;
                inParams["DeviceType"] = deviceType;
                inParams["ParentAdditionalOptions"] = parentAdditionalOptions;
                inParams["ParentDeviceType"] = parentDeviceType;
                inParams["ParentPath"] = parentPath;
                inParams["Path"] = path;
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("SetFileDeviceElement", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return Convert.ToBoolean(0);
            }
        }
        
        public bool SetIntegerElement(ulong integer, uint type) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("SetIntegerElement");
                inParams["Integer"] = integer;
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("SetIntegerElement", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return Convert.ToBoolean(0);
            }
        }
        
        public bool SetIntegerListElement(ulong[] integers, uint type) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("SetIntegerListElement");
                inParams["Integers"] = integers;
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("SetIntegerListElement", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return Convert.ToBoolean(0);
            }
        }
        
        public bool SetObjectElement(string id, uint type) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("SetObjectElement");
                inParams["Id"] = id;
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("SetObjectElement", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return Convert.ToBoolean(0);
            }
        }
        
        public bool SetObjectListElement(string[] ids, uint type) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("SetObjectListElement");
                inParams["Ids"] = ids;
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("SetObjectListElement", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return Convert.ToBoolean(0);
            }
        }
        
        public bool SetPartitionDeviceElement(string additionalOptions, uint deviceType, string path, uint type) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("SetPartitionDeviceElement");
                inParams["AdditionalOptions"] = additionalOptions;
                inParams["DeviceType"] = deviceType;
                inParams["Path"] = path;
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("SetPartitionDeviceElement", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return Convert.ToBoolean(0);
            }
        }
        
        public bool SetPartitionDeviceElementWithFlags(string additionalOptions, uint deviceType, uint flags, string path, uint type) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("SetPartitionDeviceElementWithFlags");
                inParams["AdditionalOptions"] = additionalOptions;
                inParams["DeviceType"] = deviceType;
                inParams["Flags"] = flags;
                inParams["Path"] = path;
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("SetPartitionDeviceElementWithFlags", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return Convert.ToBoolean(0);
            }
        }
        
        public bool SetQualifiedPartitionDeviceElement(string diskSignature, string partitionIdentifier, uint partitionStyle, uint type) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("SetQualifiedPartitionDeviceElement");
                inParams["DiskSignature"] = diskSignature;
                inParams["PartitionIdentifier"] = partitionIdentifier;
                inParams["PartitionStyle"] = partitionStyle;
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("SetQualifiedPartitionDeviceElement", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return Convert.ToBoolean(0);
            }
        }
        
        public bool SetStringElement(string String, uint type) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("SetStringElement");
                inParams["String"] = String;
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("SetStringElement", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return Convert.ToBoolean(0);
            }
        }
        
        public bool SetVhdDeviceElement(uint customLocate, string parentAdditionalOptions, uint parentDeviceType, string parentPath, string path, uint type) {
            if (_isEmbedded == false) {
                var inParams = _privateLateBoundObject.GetMethodParameters("SetVhdDeviceElement");
                inParams["CustomLocate"] = customLocate;
                inParams["ParentAdditionalOptions"] = parentAdditionalOptions;
                inParams["ParentDeviceType"] = parentDeviceType;
                inParams["ParentPath"] = parentPath;
                inParams["Path"] = path;
                inParams["Type"] = type;
                var outParams = _privateLateBoundObject.InvokeMethod("SetVhdDeviceElement", inParams, null);
                // ReSharper disable once PossibleNullReferenceException
                return Convert.ToBoolean(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return Convert.ToBoolean(0);
            }
        }
        
        // クラスのインスタンスを列挙する列挙子の実装です。
        public class BcdObjectCollection : object, ICollection {
            
            private readonly ManagementObjectCollection _privColObj;
            
            public BcdObjectCollection(ManagementObjectCollection objCollection) {
                _privColObj = objCollection;
            }
            
            public virtual int Count => _privColObj.Count;

            public virtual bool IsSynchronized => _privColObj.IsSynchronized;

            public virtual object SyncRoot => this;

            public virtual void CopyTo(Array array, int index) {
                _privColObj.CopyTo(array, index);
                int nCtr;
                for (nCtr = 0; nCtr < array.Length; nCtr = nCtr + 1) {
                    array.SetValue(new BcdObject((ManagementObject)array.GetValue(nCtr)), nCtr);
                }
            }
            
            public virtual IEnumerator GetEnumerator() {
                return new BcdObjectEnumerator(_privColObj.GetEnumerator());
            }
            
            public class BcdObjectEnumerator : object, IEnumerator {
                
                private readonly ManagementObjectCollection.ManagementObjectEnumerator _privObjEnum;
                
                public BcdObjectEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                    _privObjEnum = objEnum;
                }
                
                public virtual object Current => new BcdObject((ManagementObject)_privObjEnum.Current);

                public virtual bool MoveNext() {
                    return _privObjEnum.MoveNext();
                }
                
                public virtual void Reset() {
                    _privObjEnum.Reset();
                }
            }
        }
        
        // ValueType プロパティの NULL 値を扱う TypeConverter です。
        public class WmiValueTypeConverter : TypeConverter {
            
            private readonly TypeConverter _baseConverter;
            
            private readonly Type _baseType;
            
            public WmiValueTypeConverter(Type inBaseType) {
                _baseConverter = TypeDescriptor.GetConverter(inBaseType);
                _baseType = inBaseType;
            }
            
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type srcType) {
                return _baseConverter.CanConvertFrom(context, srcType);
            }
            
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
                return _baseConverter.CanConvertTo(context, destinationType);
            }
            
            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
                return _baseConverter.ConvertFrom(context, culture, value);
            }
            
            public override object CreateInstance(ITypeDescriptorContext context, IDictionary dictionary) {
                return _baseConverter.CreateInstance(context, dictionary);
            }
            
            public override bool GetCreateInstanceSupported(ITypeDescriptorContext context) {
                return _baseConverter.GetCreateInstanceSupported(context);
            }
            
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributeVar) {
                return _baseConverter.GetProperties(context, value, attributeVar);
            }
            
            public override bool GetPropertiesSupported(ITypeDescriptorContext context) {
                return _baseConverter.GetPropertiesSupported(context);
            }
            
            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
                return _baseConverter.GetStandardValues(context);
            }
            
            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) {
                return _baseConverter.GetStandardValuesExclusive(context);
            }
            
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
                return _baseConverter.GetStandardValuesSupported(context);
            }
            
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
                if (_baseType.BaseType == typeof(Enum)) {
                    if (value.GetType() == destinationType) {
                        return value;
                    }
                    return _baseConverter.ConvertTo(context, culture, value, destinationType);
                }
                if ((_baseType == typeof(bool)) 
                    && (_baseType.BaseType == typeof(ValueType))) {
                    if ((value == null) 
                        && (context != null) 
                        // ReSharper disable once PossibleNullReferenceException
                        && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false)) {
                        return "";
                    }
                    return _baseConverter.ConvertTo(context, culture, value, destinationType);
                }
                if ((context != null) 
                    // ReSharper disable once PossibleNullReferenceException
                    && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false)) {
                    return "";
                }
                return _baseConverter.ConvertTo(context, culture, value, destinationType);
            }
        }
        
        // WMI システム プロパティを表す埋め込みクラスです。
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class ManagementSystemProperties {
            
            private readonly ManagementBaseObject _privateLateBoundObject;
            
            public ManagementSystemProperties(ManagementBaseObject managedObject) {
                _privateLateBoundObject = managedObject;
            }
            
            [Browsable(true)]
            public int Genus => (int)_privateLateBoundObject["__GENUS"];

            [Browsable(true)]
            public string Class => (string)_privateLateBoundObject["__CLASS"];

            [Browsable(true)]
            public string Superclass => (string)_privateLateBoundObject["__SUPERCLASS"];

            [Browsable(true)]
            public string Dynasty => (string)_privateLateBoundObject["__DYNASTY"];

            [Browsable(true)]
            public string Relpath => (string)_privateLateBoundObject["__RELPATH"];

            [Browsable(true)]
            public int PropertyCount => (int)_privateLateBoundObject["__PROPERTY_COUNT"];

            [Browsable(true)]
            public string[] Derivation => (string[])_privateLateBoundObject["__DERIVATION"];

            [Browsable(true)]
            public string Server => (string)_privateLateBoundObject["__SERVER"];

            [Browsable(true)]
            public string Namespace => (string)_privateLateBoundObject["__NAMESPACE"];

            [Browsable(true)]
            // ReSharper disable once InconsistentNaming
            public string PATH => (string)_privateLateBoundObject["__PATH"];
        }
    }
}
