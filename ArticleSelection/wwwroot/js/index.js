window.onload = function () {
    //文章上交的时间
    var ArticleTime = document.querySelector(".time>span");
    var date = new Date();
    ArticleTime.innerText = date.toLocaleString();

    //提交按钮
    var sm = document.getElementById("submit");
    //清除按钮
    var rs = document.getElementById("reset");
    //文本框
    var txt = document.querySelector("textarea");
    //评分
    var sco = document.getElementById("score");

    //提交
    sm.onclick = function () {
        // alert("是否提交？");
        //是否为空
        if ((txt.value).trim().length == 0) {
            alert("不说点什么吗(っ °Д °;)っ");
            return false;
        }
        if ((sco.value).trim().length == 0) {
            alert("评个分呗(oﾟvﾟ)ノ");
            return false;
        }

        if (sco.value > 10) {
            sco.value = "10";
            return false;
        }
        console.log(txt.value, sco.value);
        if (window.confirm("是否提交？"))
            return true;
        else
            return false;

    }
    //清除
    rs.onclick = function () {
        txt.value = "";
    }

    //点评小图标
    //评论盒子
    var com = document.querySelector(".comment");
    var mc = document.querySelector(".M_comment_icon");
    //加内边距显示下面的内容
    var dpBox = document.querySelector(".dp_Content");

    // 768以下移动设备
    var Width = window.screen.width;
    var height = window.screen.height;

    mc.style.bottom = height / 2 - 20 + "px"; //过于僵硬
    // mc.style.bottom = "50%";//浮动过大

    if (Width < 768) {
        mc.style.display = "block";

        // 隐藏输入框
        com.style.position = "fixed";
        com.style.bottom = "-50%";
        com.style.transition = "all .4s";
        com.style.webkitTransition = "all .4s";
    }


    //点击事件
    var bool = false; //单次点击
    mc.onclick = function () {
        if (!bool) {
            com.style.left = "0";
            com.style.bottom = "0";

            mc.innerText = "X";
            mc.style.opacity = ".3";

            // txt.focus();
            //焦点动画 快捷按钮向下移动，避免超出当前界面
            function blurT() {
                setTranslateX(mc, 0);
                mc.style.opacity = "0.3";
            }

            function focusT() {
                addTransition(mc);
                setTranslateX(mc, 50);
                mc.style.opacity = "0";
            }
            txt.addEventListener("focus", focusT);
            txt.addEventListener("blur", blurT);
            sco.addEventListener("focus", focusT);
            sco.addEventListener("blur", blurT);

            bool = true;
        } else {
            com.style.bottom = "-50%";
            mc.innerText = "点评";
            mc.style.opacity = ".8";

            bool = false;
        }
    }
    //End 点评小图标
};

/*添加过渡*/
var addTransition = function (obj) {
    obj.style.webkitTransition = "all .2s"; /*兼容*/
    obj.style.transition = "all .2s";
};
/*改变位置*/
var setTranslateX = function (obj, translate) {
    obj.style.webkitTransform = "translateX(" + translate + "px)";
    obj.style.transform = "translateX(" + translate + "px)";
};