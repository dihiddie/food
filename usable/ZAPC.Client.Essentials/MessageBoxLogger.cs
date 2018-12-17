namespace ZAPC.Client.Essentials
{
    using System;
    using System.Windows.Forms;

    using JetBrains.Annotations;

    using ZAPC.Core.Logging;

    public class MessageBoxLogger : ILog
    {
        public static void ShowErrorMessage(string message) =>
            ShowMessageBoxInAppDispatcher(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void ShowFatalMessage(string message) =>
            ShowMessageBoxInAppDispatcher(message, "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void ShowInfoMessage(string message) =>
            ShowMessageBoxInAppDispatcher(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void ShowWarnMessage(string message) =>
            ShowMessageBoxInAppDispatcher(message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static void ShowDebugMessage(string message) =>
            System.Windows.Application.Current.Dispatcher.Invoke(
                () => MessageBox.Show(message, "Отладка", MessageBoxButtons.OK));

        [NotNull]
        public static string CombineMessageAndException(string message, [NotNull] Exception exception) =>
            $"{message}{Environment.NewLine}{Environment.NewLine}{GetExceptionMessage(exception)}";

        public static string GetExceptionMessage([NotNull] Exception exception)
        {
            string message = exception.Message;
            if (exception.InnerException != null)
                message += Environment.NewLine + GetExceptionMessage(exception.InnerException);
            return message;
        }

        public void Error([NotNull] Exception exception, [NotNull] string message, [NotNull] params object[] pars) =>
            ShowErrorMessage(CombineMessageAndException(string.Format(message, pars), exception));

        public void Error([NotNull] Exception exception, string message) =>
            ShowErrorMessage(CombineMessageAndException(message, exception));

        public void Error([NotNull] Exception exception) => ShowErrorMessage(GetExceptionMessage(exception));

        public void Error([NotNull] string message, [NotNull] object[] pars) =>
            ShowErrorMessage(string.Format(message, pars));

        public void Error(string message) => ShowErrorMessage(message);

        public void Error<T>([CanBeNull] T obj) => ShowErrorMessage(obj?.ToString());

        public void Info(string message) => ShowInfoMessage(message);

        public void Info([NotNull] string message, [NotNull] object[] pars) =>
            ShowInfoMessage(string.Format(message, pars));

        public void Info<T>([CanBeNull] T obj) => ShowInfoMessage(obj?.ToString());

        public void Trace(string message) => ShowDebugMessage(message);

        public void Trace([NotNull] string message, [NotNull] object[] pars) =>
            ShowDebugMessage(string.Format(message, pars));

        public void Trace<T>([CanBeNull] T obj) => ShowDebugMessage(obj?.ToString());

        public void Fatal([NotNull] Exception exception, [NotNull] string message, [NotNull] params object[] pars) =>
            ShowFatalMessage(CombineMessageAndException(string.Format(message, pars), exception));

        public void Fatal([NotNull] Exception exception, string message) =>
            ShowFatalMessage(CombineMessageAndException(message, exception));

        public void Fatal([NotNull] Exception exception) => ShowFatalMessage(GetExceptionMessage(exception));

        public void Fatal([NotNull] string message, [NotNull] object[] pars) =>
            ShowFatalMessage(string.Format(message, pars));

        public void Fatal(string message) => ShowFatalMessage(message);

        public void Fatal<T>([CanBeNull] T obj) => ShowErrorMessage(obj?.ToString());

        public void Warn(string message) => ShowWarnMessage(message);

        public void Warn([NotNull] string message, [NotNull] object[] pars) =>
            ShowWarnMessage(string.Format(message, pars));

        public void Warn<T>([CanBeNull] T obj) => ShowWarnMessage(obj?.ToString());

        public void Debug(string message) => ShowDebugMessage(message);

        public void Debug([NotNull] string message, [NotNull] object[] pars) =>
            ShowDebugMessage(string.Format(message, pars));

        public void Debug<T>([CanBeNull] T obj) => ShowDebugMessage(obj?.ToString());

        private static void ShowMessageBoxInAppDispatcher(
            string text,
            string caption,
            MessageBoxButtons buttons,
            MessageBoxIcon icon) =>
            System.Windows.Application.Current.Dispatcher.Invoke(() => MessageBox.Show(text, caption, buttons, icon));
    }
}
