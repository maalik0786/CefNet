namespace CefNet.Internal
{
	public partial class WebViewGlue
	{
		private CefAudioHandlerGlue _audioGlue;
		private readonly bool _avoidAudioGlue;
		private readonly bool _avoidJsDialogGlue;
		private CefCookieAccessFilter _cookieAccessFilterGlue;
		private CefDragHandlerGlue _dragGlue;
		private CefFocusHandlerGlue _focusGlue;

		private bool _isAudioGlueInitialized;

		private bool _isCookieAccessFilterGlueInitialized;

		private bool _isDragGlueInitialized;

		private bool _isFocusGlueInitialized;

		private bool _isJSDialogGlueInitialized;

		private bool _isKeyboardGlueInitialized;
		private bool _isResourceRequestGlueInitialized;
		private CefJSDialogHandlerGlue _jsDialogGlue;
		private CefKeyboardHandlerGlue _keyboardGlue;
		private readonly bool _partialAvoidResourceRequestGlue;
		private CefResourceRequestHandler _resourceRequestGlue;

		public WebViewGlue(IChromiumWebViewPrivate view)
		{
			WebView = view;
			Client = new CefClientGlue(this);
			LifeSpanGlue = new CefLifeSpanHandlerGlue(this);
			RenderGlue = new CefRenderHandlerGlue(this);
			DisplayGlue = new CefDisplayHandlerGlue(this);
			RequestGlue = new CefRequestHandlerGlue(this);
			DialogGlue = new CefDialogHandlerGlue(this);
			DownloadGlue = new CefDownloadHandlerGlue(this);
			FindGlue = new CefFindHandlerGlue(this);

			ContextMenuGlue = new CefContextMenuHandlerGlue(this);
			LoadGlue = new CefLoadHandlerGlue(this);

			_partialAvoidResourceRequestGlue = AvoidOverloadOnBeforeResourceLoad() && AvoidGetResourceHandler()
				&& AvoidOnResourceRedirect() && AvoidOnResourceResponse() && AvoidGetResourceResponseFilter()
				&& AvoidOnResourceLoadComplete() && AvoidOnProtocolExecution();

			_avoidJsDialogGlue = AvoidOnJSDialog() && AvoidOnBeforeUnloadDialog() && AvoidOnResetDialogState()
			                     && AvoidOnDialogClosed();

			_avoidAudioGlue = AvoidGetAudioParameters() && AvoidOnAudioStreamStarted() && AvoidOnAudioStreamPacket()
			                  && AvoidOnAudioStreamStopped() && AvoidOnAudioStreamError();
		}

		protected internal IChromiumWebViewPrivate WebView { get; }

		public CefBrowser BrowserObject { get; protected set; }

		public CefClient Client { get; }
		private CefLifeSpanHandlerGlue LifeSpanGlue { get; }
		private CefRenderHandlerGlue RenderGlue { get; }
		private CefDisplayHandlerGlue DisplayGlue { get; }
		private CefRequestHandlerGlue RequestGlue { get; }
		private CefDialogHandlerGlue DialogGlue { get; }
		private CefDownloadHandlerGlue DownloadGlue { get; }
		private CefFindHandlerGlue FindGlue { get; }

		private CefContextMenuHandlerGlue ContextMenuGlue { get; }
		private CefLoadHandlerGlue LoadGlue { get; }


		private CefResourceRequestHandler ResourceRequestGlue
		{
			get
			{
				if (_isResourceRequestGlueInitialized)
					return _resourceRequestGlue;

				if (_partialAvoidResourceRequestGlue && AvoidGetCookieAccessFilter())
					_resourceRequestGlue = null;
				else
					_resourceRequestGlue = new CefResourceRequestHandlerGlue(this);

				_isResourceRequestGlueInitialized = true;
				return _resourceRequestGlue;
			}
		}

		private CefCookieAccessFilter CookieAccessFilterGlue
		{
			get
			{
				if (_isCookieAccessFilterGlueInitialized)
					return _cookieAccessFilterGlue;

				if (AvoidOverloadCanSendCookie() && AvoidOverloadCanSaveCookie())
					_cookieAccessFilterGlue = null;
				else
					_cookieAccessFilterGlue = new CefCookieAccessFilterGlue(this);

				_isCookieAccessFilterGlueInitialized = true;
				return _cookieAccessFilterGlue;
			}
		}

		private CefFocusHandlerGlue FocusGlue
		{
			get
			{
				if (_isFocusGlueInitialized)
					return _focusGlue;

				if (AvoidOnTakeFocus()
				    && AvoidOnSetFocus()
				    && AvoidOnGotFocus())
					_focusGlue = null;
				else
					_focusGlue = new CefFocusHandlerGlue(this);

				_isFocusGlueInitialized = true;
				return _focusGlue;
			}
		}

		private CefDragHandlerGlue DragGlue
		{
			get
			{
				if (_isDragGlueInitialized)
					return _dragGlue;

				if (AvoidOnDragEnter() && AvoidOnDraggableRegionsChanged())
					_dragGlue = null;
				else
					_dragGlue = new CefDragHandlerGlue(this);

				_isDragGlueInitialized = true;
				return _dragGlue;
			}
		}

		private CefKeyboardHandlerGlue KeyboardGlue
		{
			get
			{
				if (_isKeyboardGlueInitialized)
					return _keyboardGlue;

				if (AvoidOnPreKeyEvent() && AvoidOnKeyEvent())
					_keyboardGlue = null;
				else
					_keyboardGlue = new CefKeyboardHandlerGlue(this);

				_isKeyboardGlueInitialized = true;
				return _keyboardGlue;
			}
		}

		private CefJSDialogHandlerGlue JSDialogGlue
		{
			get
			{
				if (_isJSDialogGlueInitialized)
					return _jsDialogGlue;

				if (_avoidJsDialogGlue)
					_jsDialogGlue = null;
				else
					_jsDialogGlue = new CefJSDialogHandlerGlue(this);

				_isJSDialogGlueInitialized = true;
				return _jsDialogGlue;
			}
		}

		private CefAudioHandlerGlue AudioGlue
		{
			get
			{
				if (_isAudioGlueInitialized)
					return _audioGlue;

				if (_avoidAudioGlue)
					_audioGlue = null;
				else
					_audioGlue = new CefAudioHandlerGlue(this);

				_isAudioGlueInitialized = true;
				return _audioGlue;
			}
		}


		internal void NotifyPopupBrowserCreating()
		{
			WebView.RaisePopupBrowserCreating();
		}
	}
}