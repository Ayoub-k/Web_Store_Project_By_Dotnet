    var imgs = ["/images/background/1.jpg",
        "/images/background/2.jpg",
        "/images/background/3.jpg",
        "/images/background/4.jpg",
        "/images/background/5.jpg",
        "/images/background/6.jpg"]
    var k = 0
    function slides() {
        document.getElementById("slide").src = imgs[k];
        k++;
        if (k > 5)
        k = 0
    }
    setInterval(slides, 3000)