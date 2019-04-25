window.onload=function(){
    //生成时间
    var time=document.querySelector(".time");
    
    setInterval(function(){
        var t=new Date();
        time.innerText=t.getHours()+":"+t.getMinutes();
    },100);

}