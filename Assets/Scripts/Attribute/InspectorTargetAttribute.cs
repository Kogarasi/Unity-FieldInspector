//!
//! @file InspectorTargetAttribute.cs
//! @brief Attribute for inspection targer.
//! @author koga
//!

using System;

namespace FieldInspector.Attribute {

    //!
    //! @brief Attribute for inspection target.
    //!
    [AttributeUsage( AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = false )]
    public class InspectorTarget : System.Attribute {
    }
}