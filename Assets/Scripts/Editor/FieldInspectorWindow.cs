//!
//! @file FieldInspectorWindow.cs
//! @brief Main window.
//! @author koga
//!

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;


namespace FieldInspector.Editor {

    //!
    //! @brief Main window class.
    //!
    public class FieldInspectorWindow : EditorWindow {

        static readonly Type monoType = typeof( MonoBehaviour );

        private ClassAnalyzer analyzer = new ClassAnalyzer();

        private GameObject[] selected = {};
        private Entity.DisplayFilter displayFiltter = Entity.DisplayFilter.Attributed;

        //!
        //! @brief Display GUI.
        //!
        void OnGUI(){
            EditorGUILayout.LabelField( "Display Type:", EditorStyles.boldLabel );

            displayFiltter = (Entity.DisplayFilter)EditorGUILayout.EnumPopup( displayFiltter );

            if( selected.Length == 0 ){
                EditorGUILayout.LabelField( "Please select gameobject(s)." );
            } else {
                EditorGUILayout.Space();

                foreach( var go in selected ){
                    DisplayGameObject( go );

                    EditorGUILayout.Space();
                }
            }
        }

    
        //!
        //! @brief Display for GameObject.
        //! @param[in] go GameObject for display.
        //!
        void DisplayGameObject( GameObject go ){

            // Header
            {
                EditorGUILayout.LabelField( go.name  + " - GameObject", EditorStyles.boldLabel );
            }

            EditorGUI.indentLevel++;

            var components = go.GetComponents( monoType );
            if( components.Length == 0 ){
                EditorGUILayout.LabelField( "This gameobject has not Monobehaviour component!" );
            } else {
                foreach( var component in components ){
                    DisplayComponent( component );
                }
            }

            EditorGUI.indentLevel--;
        }

        //!
        //! @brief Dispaly for Monobehaviour component.
        //! @param[in] monoComponent Monobehaviour component for display.
        //!
        void DisplayComponent( Component monoComponent ){
            EditorGUILayout.LabelField( monoComponent.GetType().FullName + " - Component" );

            analyzer.AnalyzeComponent( monoComponent );
        }

        //!
        //! @brief Update.
        //!
        void OnInspectorUpdate(){
            
            // nothing while compile.
            if( EditorApplication.isCompiling ){

                // reset analyze.
                analyzer.Clear();
                return;
            }

            selected = Selection.gameObjects;

            Repaint();
        }

        //!
        //! @brief Trigger for show window.
        //!
        [MenuItem( "Window/Field Inspector")]
        static void ShowWindow() => EditorWindow.GetWindow<FieldInspectorWindow>(  utility: true, title: "Field Inspector" );
    }
}