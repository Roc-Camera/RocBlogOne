var func = window.func || {};

func = {
    /*设置localStorage*/
    setStorage: function (name, value) {
        localStorage.setItem(name, value);
    },
   /* 获取localStorage*/
    getStorage: function (name) {
        return localStorage.getItem(name);
    },
    /*切换主题*/
    switchTheme: function () {
        var currentTheme = this.getStorage('theme') || 'Light';
        var isDark = currentTheme === 'Dark';

        if (isDark) {
            document.querySelector('body').classList.add('dark-theme');
        } else {
            document.querySelector('body').classList.remove('dark-theme');
        }
    },
    render2048Game: async function () {
        await this._loadScript('./js/2048.js');
    },
    _loadScript: async function (url) {
        let response = await fetch(url);
        var js = await response.text();
        eval(js);
    }
};