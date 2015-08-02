using UnityEditor;
using UnityEngine;
using System.Collections;

public class Tags : AssetPostprocessor {
	
	static Tags(){
		Create ();
	}
	
	/*
	* The asset need the Layer Ground on User Layer 8 and the Layer Enemy on User Layer 9
	* This script starts automatically and set the Layers to the project settings
	*/
	static void Create(){
		
		
		int layerId = 29;
		
		SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
		
		SerializedProperty it = tagManager.GetIterator();
		bool showChildren = true;
		
		bool doInsert = true;
		
		bool groundIsSet = false;
		bool enemyIsSet = false;
		
		while (it.NextVisible(showChildren)){
			
			bool isSet = false;
			
			if(it.name.Contains("User Layer")){
				
				if(it.stringValue.Equals("Ground")){
					groundIsSet = true;
				}
				
				if(it.stringValue.Equals("Enemy")){
					enemyIsSet = true;
				}
				
				
				if(it.stringValue.Equals("")){
					
					if(!groundIsSet){
						groundIsSet = true;
						it.stringValue = "Ground";
						isSet = true;
					}
					
					if(!isSet){
						if(!enemyIsSet){
							enemyIsSet = true;
							it.stringValue = "Enemy";
						}
					}
				}
			}
		}
		
		SerializedProperty layerProp = tagManager.FindProperty("layers");
		
		// Unity 5 Tag-Fix
		if (!groundIsSet || !enemyIsSet) {
			for (int i = 8; i <= 31; i++) {
				SerializedProperty sp = layerProp.GetArrayElementAtIndex(i);
				
				if(sp != null){
					if(sp.stringValue.Equals("Ground")){
						groundIsSet = true;
					}
					
					if(sp.stringValue.Equals("Enemy")){
						enemyIsSet = true;
					}
				}
			}
			
			
			if (!groundIsSet) {
				
				for(int i = 8; i <= 31; i++){
					
					SerializedProperty sp = layerProp.GetArrayElementAtIndex(i);
					
					if(sp != null){
						if(sp.stringValue.Equals("")){
							sp.stringValue = "Ground";
							groundIsSet = true;
							
							break;
						}
					}
				}
			}
			
			if (!enemyIsSet) {
				
				for(int i = 8; i <= 31; i++){
					
					SerializedProperty sp = layerProp.GetArrayElementAtIndex(i);
					
					if(sp != null){
						if(sp.stringValue.Equals("")){
							sp.stringValue = "Enemy";
							enemyIsSet = true;
							break;
						}
					}
				}
			}
		}
		
		
		
		tagManager.ApplyModifiedProperties();
		tagManager.Update ();
	}
}