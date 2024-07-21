// Static class to handle sound-related tasks
public static class SoundHelper
{
    public static void PlayBeep()
    {
        // Plays a beep sound (will be modified for future sounds)
        Console.Beep();
    }
    // Plays a sound from a file (could be used on Windows platforms)
    // Commenting out these lines of code, due to platform inconsistencies
    // There are extensions that can be addeed to enable sounds for various platforms
    /* public static void PlaySound(string fileName)
    {
        try
        {
            using (SoundPlayer player = new SoundPlayer(fileName))
            {
                player.PlaySync(); // Wait until the sound has finished playing
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing sound: " + ex.Message);
        }
    } */
}