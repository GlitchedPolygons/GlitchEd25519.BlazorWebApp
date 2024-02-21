#include <QApplication>
#include <QtWebView>
#include <QWebEngineView>
#include <QWebEnginePage>
#include <QWebEngineProfile>
#include <QWebEngineSettings>

static const QString APP_NAME("GlitchEd25519");
static const QString SETTING_ID_WINDOW_WIDTH("WindowWidth");
static const QString SETTING_ID_WINDOW_HEIGHT("WindowHeight");
static const QString SETTING_ID_WINDOW_MAXIMIZED("WindowMaximized");
static const QString PROFILE_NAME("GlitchedPolygons.Qt.WebEngine.Profile");
static const QUrl URL("https://ed25519.glitchedpolygons.com");

int main(int argc, char** argv)
{
    const QApplication app(argc, argv);

    app.setOrganizationName("Glitched Polygons");
    app.setOrganizationDomain("glitchedpolygons.com");
    app.setApplicationVersion("1.0.0");
    app.setApplicationName(APP_NAME);
    app.setApplicationDisplayName(APP_NAME);
    app.setWindowIcon(QIcon(":/favicon.ico"));

    QWebEngineProfile profile(PROFILE_NAME);

    profile.settings()->setAttribute(QWebEngineSettings::LocalStorageEnabled, true);
    profile.setPersistentStoragePath(QStandardPaths::writableLocation(QStandardPaths::AppLocalDataLocation));

    QWebEnginePage page(&profile);
    page.load(URL);

    QSettings::setDefaultFormat(QSettings::IniFormat);
    QSettings settings;

    const int savedWindowWidth = settings.value(SETTING_ID_WINDOW_WIDTH, QVariant(1024)).toInt();
    const int savedWindowHeight = settings.value(SETTING_ID_WINDOW_HEIGHT, QVariant(768)).toInt();
    const bool savedWindowMaximizationState = settings.value(SETTING_ID_WINDOW_MAXIMIZED, QVariant(true)).toBool();

    QWebEngineView view;
    view.setPage(&page);
    view.resize(savedWindowWidth, savedWindowHeight);

    if (savedWindowMaximizationState)
    {
        view.showMaximized();
    }
    else
    {
        view.show();
    }

    const int r = app.exec();

    settings.setValue(SETTING_ID_WINDOW_WIDTH, QVariant(view.width()));
    settings.setValue(SETTING_ID_WINDOW_HEIGHT, QVariant(view.height()));
    settings.setValue(SETTING_ID_WINDOW_MAXIMIZED, QVariant(view.isMaximized()));

    return r;
}
