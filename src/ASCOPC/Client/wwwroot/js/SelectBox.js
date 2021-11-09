
window.blazorSelectBox = () => {

	; (function (window) {

		'use strict';

		function hasParent(e, p) {
			if (!e) return false;
			var el = e.target || e.srcElement || e || false;
			while (el && el != p) {
				el = el.parentNode || false;
			}
			return (el !== false);
		};

		/**
		 * extend obj function
		 */
		function extend(a, b) {
			for (var key in b) {
				if (b.hasOwnProperty(key)) {
					a[key] = b[key];
				}
			}
			return a;
		}

		/**
		 * SelectFx function
		 */
		function SelectFx(el, options) {
			this.el = el;
			this.options = extend({}, this.options);
			extend(this.options, options);
			this._init();
		}

		/**
		 * SelectFx options
		 */
		SelectFx.prototype.options = {
			// if true all the links will open in a new tab.
			// if we want to be redirected when we click an option, we need to define a data-link attr on the option of the native select element
			newTab: true,
			// when opening the select element, the default placeholder (if any) is shown
			stickyPlaceholder: true,
			// callback when changing the value
			onChange: function (val) { return false; }
		}

		/**
		 * init function
		 * initialize and cache some vars
		 */
		SelectFx.prototype._init = function () {
			// check if we are using a placeholder for the native select box
			// we assume the placeholder is disabled and selected by default
			var selectedOpt = this.el.querySelector('option[selected]');
			this.hasDefaultPlaceholder = selectedOpt && selectedOpt.disabled;

			// get selected option (either the first option with attr selected or just the first option)
			this.selectedOpt = selectedOpt || this.el.querySelector('option');

			// create structure
			this._createSelectEl();

			// all options
			this.selOpts = [].slice.call(this.selEl.querySelectorAll('li[data-option]'));

			// total options
			this.selOptsCount = this.selOpts.length;

			// current index
			this.current = this.selOpts.indexOf(this.selEl.querySelector('li.cs-selected')) || -1;

			// placeholder elem
			this.selPlaceholder = this.selEl.querySelector('span.cs-placeholder');

			// init events
			this._initEvents();
		}

		/**
		 * creates the structure for the select element
		 */
		SelectFx.prototype._createSelectEl = function () {
			var self = this, options = '', createOptionHTML = function (el) {
				var optclass = '', classes = '', link = '';

				if (el.selectedOpt && !this.foundSelected && !this.hasDefaultPlaceholder) {
					classes += 'cs-selected ';
					this.foundSelected = true;
				}
				// extra classes
				if (el.getAttribute('data-class')) {
					classes += el.getAttribute('data-class');
				}
				// link options
				if (el.getAttribute('data-link')) {
					link = 'data-link=' + el.getAttribute('data-link');
				}

				if (classes !== '') {
					optclass = 'class="' + classes + '" ';
				}

				return '<div class="selection__divider"></div> <li ' + optclass + link + ' data-option data-value="' + el.value + '"><span>' + el.textContent + '</span></li>';
			};

			[].slice.call(this.el.children).forEach(function (el) {
				if (el.disabled) { return; }

				var tag = el.tagName.toLowerCase();

				if (tag === 'option') {
					options += createOptionHTML(el);
				}
				else if (tag === 'optgroup') {
					options += '<li class="cs-optgroup"><span>' + el.label + '</span><ul>';
					[].slice.call(el.children).forEach(function (opt) {
						options += createOptionHTML(opt);
					});
					options += '</ul></li>';
				}
			});

			var opts_el = '<div class="cs-options"><ul>' + options + '</ul></div>';
			this.selEl = document.createElement('div');
			this.selEl.className = this.el.className;
			this.selEl.tabIndex = this.el.tabIndex;
			this.selEl.innerHTML = '<span class="cs-placeholder">' + this.selectedOpt.textContent + '</span>' + opts_el;
			this.el.parentNode.appendChild(this.selEl);
			this.selEl.appendChild(this.el);
		}

		/**
		 * initialize the events
		 */
		SelectFx.prototype._initEvents = function () {
			var self = this;

			// open/close select
			this.selPlaceholder.addEventListener('click', function () {
				self._toggleSelect();
			});

			// clicking the options
			this.selOpts.forEach(function (opt, idx) {
				opt.addEventListener('click', function () {
					self.current = idx;
					self._changeOption();
					// close select elem
					self._toggleSelect();
				});
			});

			// close the select element if the target it´s not the select element or one of its descendants..
			document.addEventListener('click', function (ev) {
				var target = ev.target;
				if (self._isOpen() && target !== self.selEl && !hasParent(target, self.selEl)) {
					self._toggleSelect();
				}
			});

			// keyboard navigation events
			this.selEl.addEventListener('keydown', function (ev) {
				var keyCode = ev.keyCode || ev.which;

				switch (keyCode) {
					// up key
					case 38:
						ev.preventDefault();
						self._navigateOpts('prev');
						break;
					// down key
					case 40:
						ev.preventDefault();
						self._navigateOpts('next');
						break;
					// space key
					case 32:
						ev.preventDefault();
						if (self._isOpen() && typeof self.preSelCurrent != 'undefined' && self.preSelCurrent !== -1) {
							self._changeOption();
						}
						self._toggleSelect();
						break;
					// enter key
					case 13:
						ev.preventDefault();
						if (self._isOpen() && typeof self.preSelCurrent != 'undefined' && self.preSelCurrent !== -1) {
							self._changeOption();
							self._toggleSelect();
						}
						break;
					// esc key
					case 27:
						ev.preventDefault();
						if (self._isOpen()) {
							self._toggleSelect();
						}
						break;
				}
			});
		}

		/**
		 * navigate with up/dpwn keys
		 */
		SelectFx.prototype._navigateOpts = function (dir) {
			if (!this._isOpen()) {
				this._toggleSelect();
			}

			var tmpcurrent = typeof this.preSelCurrent != 'undefined' && this.preSelCurrent !== -1 ? this.preSelCurrent : this.current;

			if (dir === 'prev' && tmpcurrent > 0 || dir === 'next' && tmpcurrent < this.selOptsCount - 1) {
				// save pre selected current - if we click on option, or press enter, or press space this is going to be the index of the current option
				this.preSelCurrent = dir === 'next' ? tmpcurrent + 1 : tmpcurrent - 1;
				// remove focus class if any..
				this._removeFocus();
				// add class focus - track which option we are navigating
				classie.add(this.selOpts[this.preSelCurrent], 'cs-focus');
			}
		}

		/**
		 * open/close select
		 * when opened show the default placeholder if any
		 */
		SelectFx.prototype._toggleSelect = function () {
			// remove focus class if any..
			this._removeFocus();

			if (this._isOpen()) {
				if (this.current !== -1) {
					// update placeholder text
					this.selPlaceholder.textContent = this.selOpts[this.current].textContent;
				}
				classie.remove(this.selEl, 'cs-active');
			}
			else {
				if (this.hasDefaultPlaceholder && this.options.stickyPlaceholder) {
					// everytime we open we wanna see the default placeholder text
					this.selPlaceholder.textContent = this.selectedOpt.textContent;
				}
				classie.add(this.selEl, 'cs-active');
			}
		}

		/**
		 * change option - the new value is set
		 */
		SelectFx.prototype._changeOption = function () {
			// if pre selected current (if we navigate with the keyboard)...
			if (typeof this.preSelCurrent != 'undefined' && this.preSelCurrent !== -1) {
				this.current = this.preSelCurrent;
				this.preSelCurrent = -1;
			}

			// current option
			var opt = this.selOpts[this.current];

			// update current selected value
			this.selPlaceholder.textContent = opt.textContent;

			// change native select element´s value
			this.el.value = opt.getAttribute('data-value');

			// remove class cs-selected from old selected option and add it to current selected option
			var oldOpt = this.selEl.querySelector('li.cs-selected');
			if (oldOpt) {
				classie.remove(oldOpt, 'cs-selected');
			}
			classie.add(opt, 'cs-selected');

			// if there´s a link defined
			if (opt.getAttribute('data-link')) {
				// open in new tab?
				if (this.options.newTab) {
					window.open(opt.getAttribute('data-link'), '_blank');
				}
				else {
					window.location = opt.getAttribute('data-link');
				}
			}

			// callback
			this.options.onChange(this.el.value);
		}

		/**
		 * returns true if select element is opened
		 */
		SelectFx.prototype._isOpen = function (opt) {
			return classie.has(this.selEl, 'cs-active');
		}

		/**
		 * removes the focus class from the option
		 */
		SelectFx.prototype._removeFocus = function (opt) {
			var focusEl = this.selEl.querySelector('li.cs-focus')
			if (focusEl) {
				classie.remove(focusEl, 'cs-focus');
			}
		}

		/**
		 * add to global namespace
		 */
		window.SelectFx = SelectFx;

	})(window);

	// Classie, based on bonzo api

	(function (window) {

		'use strict';

		// class helper functions from bonzo https://github.com/ded/bonzo

		function classReg(className) {
			return new RegExp("(^|\\s+)" + className + "(\\s+|$)");
		}

		// classList support for class management
		// altho to be fair, the api sucks because it won't accept multiple classes at once
		var hasClass, addClass, removeClass;

		if ('classList' in document.documentElement) {
			hasClass = function (elem, c) {
				return elem.classList.contains(c);
			};
			addClass = function (elem, c) {
				elem.classList.add(c);
			};
			removeClass = function (elem, c) {
				elem.classList.remove(c);
			};
		}
		else {
			hasClass = function (elem, c) {
				return classReg(c).test(elem.className);
			};
			addClass = function (elem, c) {
				if (!hasClass(elem, c)) {
					elem.className = elem.className + ' ' + c;
				}
			};
			removeClass = function (elem, c) {
				elem.className = elem.className.replace(classReg(c), ' ');
			};
		}

		function toggleClass(elem, c) {
			var fn = hasClass(elem, c) ? removeClass : addClass;
			fn(elem, c);
		}

		var classie = {
			// full names
			hasClass: hasClass,
			addClass: addClass,
			removeClass: removeClass,
			toggleClass: toggleClass,
			// short names
			has: hasClass,
			add: addClass,
			remove: removeClass,
			toggle: toggleClass
		};

		// transport
		if (typeof define === 'function' && define.amd) {
			// AMD
			define(classie);
		} else {
			// browser global
			window.classie = classie;
		}

	})(window);

	(function () {
		[].slice.call(document.querySelectorAll('select.cs-select')).forEach(function (el) {
			new SelectFx(el);
		});
	})();
}

var __hasProp = {}.hasOwnProperty,
	__extends = function (child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

(function (window, document) {
	'use strict';
	var BaseModules, SelectFx;
	BaseModules = (function () {
		var addClass, capitaliseString, classReg, extendObjs, fireEvent, hasClass, hasParent, isMobile, removeClass, toggleClass;

		function BaseModules() { }

		fireEvent = function (obj, evt) {
			var evObj, fireOnThis;
			fireOnThis = obj;
			if (document.createEvent) {
				evObj = document.createEvent("MouseEvents");
				evObj.initEvent(evt, true, false);
				return fireOnThis.dispatchEvent(evObj);
			} else if (document.createEventObject) {
				evObj = document.createEventObject();
				return fireOnThis.fireEvent("on" + evt, evObj);
			}
		};

		capitaliseString = function (string) {
			return string.charAt(0).toUpperCase() + string.slice(1).toLowerCase();
		};

		classReg = function (className) {
			return new RegExp("(^|\\s+)" + className + "(\\s+|$)");
		};

		hasClass = function (elem, c) {
			return elem.className.indexOf(c) !== -1;
		};

		addClass = function (elem, c) {
			return elem.className = "" + elem.className + " " + c;
		};

		removeClass = function (elem, c) {
			return elem.className = elem.className.replace(classReg(c), '');
		};

		toggleClass = function (elem, c) {
			var fn;
			fn = (hasClass(elem, c) ? removeClass : addClass);
			return fn(elem, c);
		};

		extendObjs = function (obj1, obj2) {
			var e, p;
			for (p in obj2) {
				try {
					if (obj2[p].constructor === Object) {
						obj1[p] = extendObjs(obj1[p], obj2[p]);
					} else {
						obj1[p] = obj2[p];
					}
				} catch (_error) {
					e = _error;
					obj1[p] = obj2[p];
				}
			}
			return obj1;
		};

		hasParent = function (e, p) {
			var el;
			if (!e) {
				return false;
			}
			el = e.target || e.srcElement || e || false;
			while (el && el !== p) {
				el = el.parentNode || false;
			}
			return el !== false;
		};

		isMobile = function () {
			return navigator.userAgent.match(/Android|BlackBerry|iPhone|iPad|iPod|Opera Mini|IEMobile/i);
		};

		BaseModules.prototype.has = hasClass;

		BaseModules.prototype.add = addClass;

		BaseModules.prototype.remove = removeClass;

		BaseModules.prototype.toggle = toggleClass;

		BaseModules.prototype.extend = extendObjs;

		BaseModules.prototype.hasParent = hasParent;

		BaseModules.prototype.isMobile = isMobile;

		BaseModules.prototype.fireEvent = fireEvent;

		BaseModules.prototype.capitalise = capitaliseString;

		return BaseModules;

	})();
	SelectFx = (function (_super) {
		__extends(SelectFx, _super);

		SelectFx.options = {
			onMobile: true,
			classes: {
				baseClass: "sfx-select",
				styleClass: "sfx-default",
				selectedClass: "sfx-selected",
				placeholderClass: "sfx-placeholder",
				optgroupClass: "sfx-optgroup",
				optionsClass: "sfx-options",
				focusClass: "sfx-focus",
				activeClass: "sfx-active",
				mobileClass: "sfx-mobile"
			},
			onChange: function (val) {
				return false;
			}
		};

		SelectFx.newTab = true;

		SelectFx.stickyPlaceholder = true;

		function SelectFx(el, options) {
			options = this.extend(this.constructor.options, options);
			this.el = el;
			this.options = options;
			this._init();
		}

		SelectFx.prototype._init = function () {
			var selectedOpt;
			selectedOpt = this.el.querySelector("option[selected]");
			this.hasDefaultPlaceholder = selectedOpt && selectedOpt.disabled;
			this.selectedOpt = selectedOpt || this.el.querySelector("option");
			this._createSelectEl();
			this.selOpts = [].slice.call(this.selEl.querySelectorAll("li[data-option]"));
			this.selOptsCount = this.selOpts.length;
			this.current = this.selOpts.indexOf(this.selEl.querySelector("." + this.options.classes.selectedClass)) || -1;
			this.selPlaceholder = this.selEl.querySelector("." + this.options.classes.placeholderClass);
			return this._initEvents();
		};

		SelectFx.prototype._createSelectEl = function () {
			var classMobile, createOptionHTML, options, opts_el, self;
			self = this;
			options = "";
			createOptionHTML = function (el) {
				var classes, link, optclass;
				optclass = "";
				classes = "";
				link = "";
				if ((self.selectedOpt.value === el.value) && !self.foundSelected && !self.hasDefaultPlaceholder) {
					classes += "" + self.options.classes.selectedClass + " ";
					self.foundSelected = true;
				}
				if (el.getAttribute("data-class")) {
					classes += el.getAttribute("data-class");
				}
				if (el.getAttribute("data-link")) {
					link = "data-link=" + el.getAttribute("data-link");
				}
				if (classes !== "") {
					optclass = "class=\"" + classes + "\" ";
				}
				if (el.value !== '' && el.text === '') {
					return "<li " + optclass + link + " data-option data-value=\"" + el.value + "\"><span>" + el.value + "</span></li>";
				} else {
					return "<li " + optclass + link + " data-option data-value=\"" + el.value + "\"><span>" + el.textContent + "</span></li>";
				}
			};
			[].slice.call(this.el.children).forEach(function (el) {
				var tag;
				if (el.disabled) {
					return;
				}
				tag = el.tagName.toLowerCase();
				if (tag === "option" && el.value !== '') {
					return options += createOptionHTML(el);
				} else if (tag === "optgroup") {
					options += ("<li data-optgroup class=\"" + self.options.classes.optgroupClass + "\"><span class=\"" + self.options.classes.optgroupClass + "-title\">") + el.label + "</span><ul>";
					[].slice.call(el.children).forEach(function (opt) {
						if (opt.value !== '') {
							return options += createOptionHTML(opt);
						}
					});
					return options += "</ul></li>";
				}
			});
			classMobile = this.isMobile() && this.options.onMobile ? this.options.mobileClass : '';
			opts_el = ("<div class=\"" + this.options.classes.optionsClass + "\"><ul>") + options + "</ul></div>";
			this.selEl = document.createElement("div");
			this.selEl.className = "" + this.options.classes.baseClass + " " + this.options.classes.styleClass;
			this.selEl.tabIndex = this.el.tabIndex;
			this.selEl.id = "select" + (this.capitalise(this.el.getAttribute('id')));
			this.selEl.innerHTML = ("<span class=\"" + this.options.classes.placeholderClass + "\"> <dl><dt>") + this.selectedOpt.textContent + "</dl></dt></span>" + opts_el;
			this.el.parentNode.appendChild(this.selEl);
			return this.selEl.appendChild(this.el);
		};

		SelectFx.prototype._initEvents = function () {
			var self;
			self = this;
			if (this.el.labels[0]) {
				this.el.labels[0].addEventListener("click", function () {
					self.fireEvent(self.selPlaceholder, 'click');
					return event.stopPropagation();
				});
			}
			this.selPlaceholder.addEventListener("click", function () {
				return self._toggleSelect();
			});
			this.selOpts.forEach(function (opt, idx) {
				return opt.addEventListener("click", function () {
					self.current = idx;
					self._changeOption();
					return self._toggleSelect();
				});
			});
			document.addEventListener("click", function (ev) {
				var target;
				target = ev.target;
				if (self._isOpen() && target !== self.selEl && !self.hasParent(target, self.selEl)) {
					return self._toggleSelect();
				}
			});
			return this.selEl.addEventListener("keydown", function (ev) {
				var keyCode;
				keyCode = ev.keyCode || ev.which;
				switch (keyCode) {
					case 38:
						ev.preventDefault();
						return self._navigateOpts("prev");
					case 40:
						ev.preventDefault();
						return self._navigateOpts("next");
					case 32:
						ev.preventDefault();
						if (self._isOpen() && typeof self.preSelCurrent !== "undefined" && self.preSelCurrent !== -1) {
							self._changeOption();
						}
						return self._toggleSelect();
					case 13:
						ev.preventDefault();
						if (self._isOpen() && typeof self.preSelCurrent !== "undefined" && self.preSelCurrent !== -1) {
							self._changeOption();
							return self._toggleSelect();
						}
						break;
					case 27:
						ev.preventDefault();
						if (self._isOpen()) {
							return self._toggleSelect();
						}
				}
			});
		};

		SelectFx.prototype._navigateOpts = function (dir) {
			var tmpcurrent;
			if (!this._isOpen()) {
				this._toggleSelect();
			}
			tmpcurrent = (typeof this.preSelCurrent !== "undefined" && this.preSelCurrent !== -1 ? this.preSelCurrent : this.current);
			if (dir === "prev" && tmpcurrent > 0 || dir === "next" && tmpcurrent < this.selOptsCount - 1) {
				this.preSelCurrent = (dir === "next" ? tmpcurrent + 1 : tmpcurrent - 1);
				this._removeFocus();
				return this.add(this.selOpts[this.preSelCurrent], "" + this.options.classes.focusClass);
			}
		};

		SelectFx.prototype._toggleSelect = function () {
			this._removeFocus();
			if (this._isOpen()) {
				if (this.current !== -1) {
					this.selPlaceholder.querySelector("dl dt").textContent = this.selOpts[this.current].textContent;
				}
				return this.remove(this.selEl, "" + this.options.classes.activeClass);
			} else if (!this._isOpen()) {
				if (this.hasDefaultPlaceholder && this.constructor.stickyPlaceholder) {
					this.selPlaceholder.querySelector("dl dt").textContent = this.selectedOpt.textContent;
				}
				return this.add(this.selEl, "" + this.options.classes.activeClass);
			}
		};

		SelectFx.prototype._changeOption = function () {
			var oldOpt, opt;
			if (typeof this.preSelCurrent !== "undefined" && this.preSelCurrent !== -1) {
				this.current = this.preSelCurrent;
				this.preSelCurrent = -1;
			}
			opt = this.selOpts[this.current];
			this.selPlaceholder.querySelector("dl dt").textContent = opt.textContent;
			this.el.value = opt.getAttribute("data-value");
			oldOpt = this.selEl.querySelector("." + this.options.classes.selectedClass);
			if (oldOpt) {
				this.remove(oldOpt, "" + this.options.classes.selectedClass);
			}
			this.add(opt, "" + this.options.classes.selectedClass);
			if (opt.getAttribute("data-link")) {
				if (this.constructor.newTab) {
					window.open(opt.getAttribute("data-link"), "_blank");
				} else {
					window.location = opt.getAttribute("data-link");
				}
			}
			return this.options.onChange(this.el.value);
		};

		SelectFx.prototype._isOpen = function (opt) {
			return this.has(this.selEl, "" + this.options.classes.activeClass);
		};

		SelectFx.prototype._removeFocus = function (opt) {
			var focusEl;
			focusEl = this.selEl.querySelector("." + this.options.classes.focusClass);
			if (focusEl) {
				return this.remove(focusEl, "" + this.options.classes.focusClass);
			}
		};

		return SelectFx;

	})(BaseModules);
	return window.SelectFx = SelectFx;
})(window, document);