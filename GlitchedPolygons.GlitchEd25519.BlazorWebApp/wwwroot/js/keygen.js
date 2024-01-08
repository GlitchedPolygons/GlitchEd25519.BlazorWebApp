
function InitKeygen() 
{
    const keygenButton = document.getElementById('keygenButton');

    const entropy = document.getElementById('paintCanvasEntropy');
    const paintCanvas = document.querySelector('.js-paint');
    const context = paintCanvas.getContext('2d');

    let x = 0, y = 0;
    let isMouseDown = false;

    const configContext = () =>
    {
        context.strokeStyle = '#401bc2';
        context.lineCap = 'round';
        context.lineWidth = 4;
    }

    configContext();

    const stopDrawing = () =>
    {
        isMouseDown = false;
    }

    const startDrawing = event =>
    {
        event.preventDefault();

        isMouseDown = true;

        if (event.changedTouches)
        {
            const boundingRect = paintCanvas.getBoundingClientRect();

            [x, y] =
                [
                    event.changedTouches[0].clientX - boundingRect.left,
                    event.changedTouches[0].clientY - boundingRect.top
                ];
        }
        else
        {
            [x, y] =
                [
                    event.offsetX,
                    event.offsetY
                ];
        }
    }

    const drawLine = event =>
    {
        event.preventDefault();

        if (isMouseDown)
        {
            const boundingRect = paintCanvas.getBoundingClientRect();

            const newX = event.changedTouches
                ? event.changedTouches[0].clientX - boundingRect.left
                : event.offsetX;

            const newY = event.changedTouches
                ? event.changedTouches[0].clientY - boundingRect.top
                : event.offsetY;

            context.beginPath();
            context.moveTo(x, y);
            context.lineTo(newX, newY);
            context.stroke();

            x = newX;
            y = newY;

            entropy.value = newX + newY;
            entropy.dispatchEvent(new Event('input', { bubbles: true }));
        }
    }

    const clearCanvas = () =>
    {
        context.clearRect(0, 0, paintCanvas.width, paintCanvas.height);
        //setTimeout(() => context.clearRect(0, 0, paintCanvas.width, paintCanvas.height), 2048);
    }

    paintCanvas.addEventListener('mousedown', startDrawing);
    paintCanvas.addEventListener('touchstart', startDrawing);

    paintCanvas.addEventListener('mousemove', drawLine);
    paintCanvas.addEventListener('touchmove', drawLine);

    paintCanvas.addEventListener('mouseup', stopDrawing);
    paintCanvas.addEventListener('mouseout', stopDrawing);
    paintCanvas.addEventListener('touchend', stopDrawing);
    paintCanvas.addEventListener('touchcancel', stopDrawing);

    keygenButton.addEventListener('click', clearCanvas);

    const onResize = function(event)
    {
        const windowDimensions =
            {
                width: window.innerWidth,
                height: window.innerHeight
            };

        if (windowDimensions.width < 641)
        {
            paintCanvas.width = windowDimensions.width - 50;
            paintCanvas.height = 256;
        }
        else if (windowDimensions.width < 1250)
        {
            paintCanvas.width = windowDimensions.width - 290;
            paintCanvas.height = 384;
        }
        else
        {
            paintCanvas.width = 1024;
            paintCanvas.height = 512;
        }

        configContext();
    };

    window.addEventListener('resize', onResize, true);

    onResize(null);
}