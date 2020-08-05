
window.blazorScrollToElementId = (elementId) => {
    var element = document.getElementById(elementId);
    if (!element) {
        console.warn('element was not found', elementId);
        return false;
    }

    element.scrollIntoView({ block: "start", behavior: "smooth" });
    return true;
}
$(document).ready(function () {

    // set the starting position of the cursor outside of the screen
    let clientX = -100;
    let clientY = -100;
    const innerCursor = document.querySelector(".cursor--small");

    const initCursor = () => {
        // add listener to track the current mouse position
        document.addEventListener("mousemove", e => {
            clientX = e.clientX;
            clientY = e.clientY;
        });

        // transform the innerCursor to the current mouse position
        // use requestAnimationFrame() for smooth performance
        const render = () => {
                innerCursor.style.transform = `translate(${clientX}px, ${clientY}px)`;
                // if you are already using TweenMax in your project, you might as well
                // use TweenMax.set() instead
                // TweenMax.set(innerCursor, {
                //   x: clientX,
                //   y: clientY
                // });

                requestAnimationFrame(render);
        };

        requestAnimationFrame(render);
    };

    initCursor();



    let lastX = 0;
    let lastY = 0;
    let isStuck = false;
    let showCursor = false;
    let group, stuckX, stuckY, fillOuterCursor;

    const initCanvas = () => {
        const canvas = document.querySelector(".cursor--canvas");
        const shapeBounds = {
            width: 75,
            height: 75
        };
        paper.setup(canvas);
        const strokeColor =  "#946bf9";
        const strokeWidth = 1;
        const segments = 8;
        const radius = 15;

        // we'll need these later for the noisy circle
        const noiseScale = 150; // speed
        const noiseRange = 4; // range of distortion
        let isNoisy = false; // state

        // the base shape for the noisy circle
        const polygon = new paper.Path.RegularPolygon(
            new paper.Point(0, 0),
            segments,
            radius
        );
        polygon.strokeColor = strokeColor;
        polygon.strokeWidth = strokeWidth;
        polygon.smooth();
        group = new paper.Group([polygon]);
        group.applyMatrix = false;

        const noiseObjects = polygon.segments.map(() => new SimplexNoise());
        let bigCoordinates = [];

        // function for linear interpolation of values
        const lerp = (a, b, n) => {
            return (1 - n) * a + n * b;
        };

        // function to map a value from one range to another range
        const map = (value, in_min, in_max, out_min, out_max) => {
            return (
                ((value - in_min) * (out_max - out_min)) / (in_max - in_min) + out_min
            );
        };

        // the draw loop of Paper.js 
        // (60fps with requestAnimationFrame under the hood)
        paper.view.onFrame = event => {
            // using linear interpolation, the circle will move 0.2 (20%)
            // of the distance between its current position and the mouse
            // coordinates per Frame
            lastX = lerp(lastX, clientX, 0.2);
            lastY = lerp(lastY, clientY, 0.2);
            group.position = new paper.Point(lastX, lastY);
        }
    }

    initCanvas();


});

$(document).ready(function () {
    if (window.matchMedia("(max-width: 450px)").matches) {
        new SmoothScroll(document, 120, 12);
    }
});

function SmoothScroll(target, speed, smooth) {
    if (target === document)
        target = (document.scrollingElement
            || document.documentElement
            || document.body.parentNode
            || document.body) // cross browser support for document scrolling

    var moving = false
    var pos = target.scrollTop
    var frame = target === document.body
        && document.documentElement
        ? document.documentElement
        : target // safari is the new IE
        target.addEventListener('mousewheel', scrolled, { passive: false })
        target.addEventListener('DOMMouseScroll', scrolled, { passive: false })

    function scrolled(e) {

        e.preventDefault(); // disable default scrolling

        var delta = normalizeWheelDelta(e)

        pos += -delta * speed
        pos = Math.max(0, Math.min(pos, target.scrollHeight - frame.clientHeight)) // limit scrolling

        if (!moving) update()

    }

    function normalizeWheelDelta(e) {
        if (e.detail) {
            if (e.wheelDelta)
                return e.wheelDelta / e.detail / 40 * (e.detail > 0 ? 1 : -1) // Opera
            else
                return -e.detail / 3 // Firefox
        } else
            return e.wheelDelta / 120 // IE,Safari,Chrome
    }

    function update() {
        moving = true

        var delta = (pos - target.scrollTop) / smooth

        target.scrollTop += delta

        if (Math.abs(delta) > 0.5)
            requestFrame(update)
        else
            moving = false
    }

    var requestFrame = function () { // requestAnimationFrame cross browser
        return (
            window.requestAnimationFrame ||
            window.webkitRequestAnimationFrame ||
            window.mozRequestAnimationFrame ||
            window.oRequestAnimationFrame ||
            window.msRequestAnimationFrame ||
            function (func) {
                window.setTimeout(func, 1000 / 50);
            }
        );
    }()
}



