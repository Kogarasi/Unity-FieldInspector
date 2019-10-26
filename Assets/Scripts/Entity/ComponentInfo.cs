//!
//! @file ComponentStructure.cs
//! @brief Monobehaviour Component Data Structure
//! @author koga
//!

using System;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;

namespace FieldInspector.Entity {

    //!
    //! @brief Monobehaviour Component Data Strcture
    //!
    public class ComponentInfo {
        private Type type;

        public Dictionary<string, FieldInfo> fieldMetadata {
            get;
            private set;
        } = new Dictionary<string, FieldInfo>();

        public ComponentInfo( Type type ){
            this.type = type;

            GetFieldMetadata();
        }

        private void GetFieldMetadata(){

            // Get Field Info(s).
            var fieldInfos = type.GetFields( BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );

            foreach( var info in fieldInfos ){
                fieldMetadata[ info.Name ] = info;
            }

            // memo: なんでstringなんだっけ。
        }
    }
}
