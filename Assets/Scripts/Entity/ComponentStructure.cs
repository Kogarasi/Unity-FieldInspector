//!
//! @file ComponentStructure.cs
//! @brief Monobehaviour Component Data Structure
//! @author koga
//!

using System;
using System.Collections.Generic;
using System.Reflection;

namespace FieldInspector.Entity {

    //!
    //! @brief Monobehaviour Component Data Strcture
    //!
    public class ComponentStructure {
        private Type type;
        private Dictionary<string, FieldInfo> fieldMetadata = new Dictionary<string, FieldInfo>();

        public ComponentStructure( Type type ){
            this.type = type;

            GetFieldMetadata();
        }

        private void GetFieldMetadata(){
            var fieldInfos = type.GetFields( BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );

            foreach( var info in fieldInfos ){
                //Debug.Log( info.FieldType.Name + info.FieldType.GetHashCode() );
            }

        }
    }
}
