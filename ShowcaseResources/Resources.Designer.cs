﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShowcaseResources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ShowcaseResources.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Comment.
        /// </summary>
        public static string CommentContentField {
            get {
                return ResourceManager.GetString("CommentContentField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter a comment with a max length of 400..
        /// </summary>
        public static string CommentContentFieldLengthError {
            get {
                return ResourceManager.GetString("CommentContentFieldLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occured and the post failed to create..
        /// </summary>
        public static string CreatePostFailed {
            get {
                return ResourceManager.GetString("CreatePostFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New post created successfully!.
        /// </summary>
        public static string CreatePostSuccess {
            get {
                return ResourceManager.GetString("CreatePostSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occured getting the list of posts..
        /// </summary>
        public static string GetAllPostsFailed {
            get {
                return ResourceManager.GetString("GetAllPostsFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occured generating the new post..
        /// </summary>
        public static string GetPostFailed {
            get {
                return ResourceManager.GetString("GetPostFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Posts have been created..
        /// </summary>
        public static string NoPostsCreated {
            get {
                return ResourceManager.GetString("NoPostsCreated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to alert-danger.
        /// </summary>
        public static string StatusFailed {
            get {
                return ResourceManager.GetString("StatusFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to alert-info.
        /// </summary>
        public static string StatusInfo {
            get {
                return ResourceManager.GetString("StatusInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to alert-success.
        /// </summary>
        public static string StatusSuccess {
            get {
                return ResourceManager.GetString("StatusSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occured while updating the post..
        /// </summary>
        public static string UpdatePostFailed {
            get {
                return ResourceManager.GetString("UpdatePostFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Post updated sucessfully!.
        /// </summary>
        public static string UpdatePostSuccess {
            get {
                return ResourceManager.GetString("UpdatePostSuccess", resourceCulture);
            }
        }
    }
}
