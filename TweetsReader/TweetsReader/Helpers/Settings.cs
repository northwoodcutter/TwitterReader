// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace TweetsReader.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string AuthorName = "brodsky_joseph";
    private static readonly string DefaultAuthorName = "brodsky_joseph";

    #endregion

    public static string SettingsAuthorName
    {
      get
      {
        return AppSettings.GetValueOrDefault<string>(AuthorName, DefaultAuthorName);
      }
      set
      {
        AppSettings.AddOrUpdateValue<string>(AuthorName, value);
      }
    }

  }
}