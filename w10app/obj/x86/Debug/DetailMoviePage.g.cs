﻿#pragma checksum "D:\Works\Phims14\w10app\w10app\DetailMoviePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "45D78F12BEBDE0ACE17D0D87420EDC67"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace w10app
{
    partial class DetailMoviePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element1 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 1071 "..\..\..\DetailMoviePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element1).Click += this.FullScreenClick;
                    #line default
                }
                break;
            case 2:
                {
                    this.AppBar = (global::Windows.UI.Xaml.Controls.AppBar)(target);
                }
                break;
            case 3:
                {
                    this.HamburgerButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 1125 "..\..\..\DetailMoviePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.HamburgerButton).Click += this.HamburgerClick;
                    #line default
                }
                break;
            case 4:
                {
                    this.SearchTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.SearchButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 1131 "..\..\..\DetailMoviePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.SearchButton).Click += this.SearchClick;
                    #line default
                }
                break;
            case 6:
                {
                    this.MenuSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 7:
                {
                    this.MenuListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 1183 "..\..\..\DetailMoviePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.MenuListView).SelectionChanged += this.MenuSelectionChanged;
                    #line default
                }
                break;
            case 8:
                {
                    this.PageContent = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 9:
                {
                    this.MovieMedia = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 10:
                {
                    this.BannerGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 11:
                {
                    this.EpisodeGridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            case 12:
                {
                    global::Windows.UI.Xaml.Controls.Pivot element12 = (global::Windows.UI.Xaml.Controls.Pivot)(target);
                    #line 1255 "..\..\..\DetailMoviePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Pivot)element12).SelectionChanged += this.PivotChanged;
                    #line default
                }
                break;
            case 13:
                {
                    this.FacebookCommentWebView = (global::Windows.UI.Xaml.Controls.WebView)(target);
                }
                break;
            case 14:
                {
                    this.ActorGridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            case 15:
                {
                    this.MovieGridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    #line 1318 "..\..\..\DetailMoviePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)this.MovieGridView).ItemClick += this.DetailMovieClick;
                    #line default
                }
                break;
            case 16:
                {
                    this.MovieContentTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17:
                {
                    this.MovieNumberViewTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18:
                {
                    this.MovieYearTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19:
                {
                    this.MovieCountryTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 20:
                {
                    this.MovieTypeTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 21:
                {
                    global::Windows.UI.Xaml.Controls.Button element21 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 1249 "..\..\..\DetailMoviePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element21).Click += this.EpisodeClick;
                    #line default
                }
                break;
            case 22:
                {
                    this.MovieImageImageBrush = (global::Windows.UI.Xaml.Media.ImageBrush)(target);
                }
                break;
            case 23:
                {
                    global::Windows.UI.Xaml.Controls.Grid element23 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 1215 "..\..\..\DetailMoviePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)element23).Tapped += this.WatchMovieTapped;
                    #line default
                }
                break;
            case 24:
                {
                    this.MovieNameTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 25:
                {
                    this.MovieRatingCallisto = (global::Callisto.Controls.Rating)(target);
                    #line 1234 "..\..\..\DetailMoviePage.xaml"
                    ((global::Callisto.Controls.Rating)this.MovieRatingCallisto).Tapped += this.RatingTapped;
                    #line default
                }
                break;
            case 26:
                {
                    this.MovieRatingTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

