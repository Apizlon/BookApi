﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBookApp.DataAccess.SqlScripts {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Sql {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Sql() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MyBookApp.DataAccess.SqlScripts.Sql", typeof(Sql).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на INSERT INTO public.&quot;Authors&quot; (&quot;FullName&quot;,&quot;DateOfBirth&quot;)
        ///VALUES (@FullName,@DateOfBirth)
        ///RETURNING &quot;Id&quot;;.
        /// </summary>
        internal static string AddAuthor {
            get {
                return ResourceManager.GetString("AddAuthor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на INSERT INTO &quot;Books&quot; (&quot;Name&quot;,&quot;Description&quot;,&quot;AuthorId&quot;,&quot;PublisherId&quot;)
        ///VALUES (@Name,@Description,@AuthorId,@PublisherId)
        ///RETURNING &quot;Id&quot;;.
        /// </summary>
        internal static string AddBook {
            get {
                return ResourceManager.GetString("AddBook", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на INSERT INTO &quot;Publishers&quot; (&quot;Name&quot;)
        ///VALUES (@Name)
        ///RETURNING &quot;Id&quot;;.
        /// </summary>
        internal static string AddPublisher {
            get {
                return ResourceManager.GetString("AddPublisher", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на DELETE FROM &quot;Authors&quot; WHERE &quot;Id&quot; = @Id;.
        /// </summary>
        internal static string DeleteAuthor {
            get {
                return ResourceManager.GetString("DeleteAuthor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на DELETE FROM &quot;Books&quot; WHERE &quot;Id&quot; = @Id;.
        /// </summary>
        internal static string DeleteBook {
            get {
                return ResourceManager.GetString("DeleteBook", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на DELETE FROM &quot;Publishers&quot; WHERE &quot;Id&quot; = @Id;.
        /// </summary>
        internal static string DeletePublisher {
            get {
                return ResourceManager.GetString("DeletePublisher", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT count(1) FROM &quot;Authors&quot; WHERE &quot;Id&quot; = @Id;.
        /// </summary>
        internal static string ExistsAuthor {
            get {
                return ResourceManager.GetString("ExistsAuthor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT count(1) FROM &quot;Books&quot; WHERE &quot;Id&quot; = @Id;.
        /// </summary>
        internal static string ExistsBook {
            get {
                return ResourceManager.GetString("ExistsBook", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT count(1) FROM &quot;Publishers&quot; WHERE &quot;Id&quot; = @Id;.
        /// </summary>
        internal static string ExistsPublisher {
            get {
                return ResourceManager.GetString("ExistsPublisher", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT &quot;Id&quot;,&quot;FullName&quot;,&quot;DateOfBirth&quot; FROM &quot;Authors&quot;
        ///WHERE &quot;Id&quot; = @Id;.
        /// </summary>
        internal static string GetAuthor {
            get {
                return ResourceManager.GetString("GetAuthor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT &quot;Id&quot;,&quot;Name&quot;,&quot;Description&quot;,&quot;AuthorId&quot;,&quot;PublisherId&quot; FROM &quot;Books&quot;
        ///WHERE &quot;Id&quot; = @Id;.
        /// </summary>
        internal static string GetBook {
            get {
                return ResourceManager.GetString("GetBook", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT &quot;Id&quot;,&quot;Name&quot;,&quot;Description&quot;,&quot;AuthorId&quot;,&quot;PublisherId&quot; FROM &quot;Books&quot;
        ///WHERE &quot;AuthorId&quot; = @AuthorId;.
        /// </summary>
        internal static string GetBooksByAuthorId {
            get {
                return ResourceManager.GetString("GetBooksByAuthorId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT &quot;Id&quot;,&quot;Name&quot;,&quot;Description&quot;,&quot;AuthorId&quot;,&quot;PublisherId&quot; FROM &quot;Books&quot;
        ///WHERE &quot;PublisherId&quot; = @PublisherId;.
        /// </summary>
        internal static string GetBooksByPublisherId {
            get {
                return ResourceManager.GetString("GetBooksByPublisherId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT &quot;Id&quot;,&quot;Name&quot; FROM &quot;Publishers&quot;
        ///WHERE &quot;Id&quot; = @Id;.
        /// </summary>
        internal static string GetPublisher {
            get {
                return ResourceManager.GetString("GetPublisher", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на UPDATE &quot;Authors&quot;
        ///SET
        ///    &quot;FullName&quot; = CASE WHEN @FullName IS NULL THEN &quot;FullName&quot; ELSE @FullName END,
        ///    &quot;DateOfBirth&quot; = CASE WHEN @DateOfBirth IS NULL THEN &quot;DateOfBirth&quot; ELSE @DateOfBirth END
        ///WHERE &quot;Id&quot; = @Id;.
        /// </summary>
        internal static string UpdateAuthor {
            get {
                return ResourceManager.GetString("UpdateAuthor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на UPDATE &quot;Books&quot;
        ///SET
        ///    &quot;Name&quot; = CASE WHEN @Name IS NULL THEN &quot;Name&quot; ELSE @Name END,
        ///    &quot;Description&quot; = CASE WHEN @Description IS NULL THEN &quot;Description&quot; ELSE @Description END,
        ///    &quot;AuthorId&quot; = CASE WHEN @AuthorId = 0 THEN &quot;AuthorId&quot; ELSE @AuthorId END,
        ///    &quot;PublisherId&quot; = CASE WHEN @PublisherId = 0 THEN &quot;PublisherId&quot; ELSE @PublisherId END
        ///WHERE &quot;Id&quot; = @Id;.
        /// </summary>
        internal static string UpdateBook {
            get {
                return ResourceManager.GetString("UpdateBook", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на UPDATE &quot;Publishers&quot;
        ///SET &quot;Name&quot; = CASE WHEN @Name IS NULL THEN &quot;Name&quot; ELSE @Name END
        ///WHERE &quot;Id&quot; = @Id;.
        /// </summary>
        internal static string UpdatePublisher {
            get {
                return ResourceManager.GetString("UpdatePublisher", resourceCulture);
            }
        }
    }
}
