
function InitCopyButtonLabel(buttonElementId)
{
    const copyButton = document.getElementById(buttonElementId);
    const defaultLabelCopyButton = copyButton.innerHTML;

    copyButton.addEventListener('click', () =>
    {
        copyButton.innerHTML = 'Copied...';

        setTimeout(() => copyButton.innerHTML = defaultLabelCopyButton, 1337);
    });
}