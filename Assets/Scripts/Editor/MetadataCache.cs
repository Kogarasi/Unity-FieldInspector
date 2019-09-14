//!
//! @file MetadataCache.cs
//! @brief Cache system for type metadata.
//! @author koga
//!

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FieldInspector.Editor {

    //!
    //! @brief Cache for Type metadata
    //!
    public class MetadataCache {

        private Dictionary<int, Type> types = new Dictionary<int, Type>();
        private Dictionary<int, Entity.ComponentStructure> componentStructures = new Dictionary<int, Entity.ComponentStructure>();

        //!
        //! @brief Get Type of Monobehaviour component.
        //! @param[in] component Monobehaviour compoennt.
        //! @return System.Type Type of Monobehaviour component.
        //!
        public Type GetComponentType( Component component ){
            var identifier = component.GetInstanceID();
            var type = types.FirstOrDefault( pair => pair.Key == identifier ).Value;

            if( type == null ){
                type = component.GetType();
                types.Add( identifier, type );
            }

            return type;
        }

        //!
        //! @brief Get Component Structure of Monobehaviour component.
        //! @param[in] component Monobehaviour component.
        //! @return ComponentStructure Component Structure instance of Monobehaviour component.
        public Entity.ComponentStructure GetComponentStructure( Component component ){
            return null;
        }

        //!
        //! @brief Clear cache.
        //!
        public void Clear(){
            types.Clear();
            componentStructures.Clear();
        }
    }
}