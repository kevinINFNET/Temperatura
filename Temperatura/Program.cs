namespace MonitoramentoDeTemperatura
{
    public delegate void TemperaturaCriticaEventHandler(object sender, TemperaturaEventArgs e);
    public class TemperaturaEventArgs : EventArgs
    {
public double TemperaturaAtual { get; }
  public TemperaturaEventArgs(double temperaturaAtual)
  {
 TemperaturaAtual = temperaturaAtual;
   }
    }
 public class Sensor
    {
  public event TemperaturaCriticaEventHandler TemperaturaCritica;
   private double _limiteCritico;
   public Sensor(double limiteCritico)
 {
  _limiteCritico = limiteCritico;
}
  public void VerificarTemperatura(double temperatura)
{
  Console.WriteLine($"Temperatura atual: {temperatura}°C");
  if (temperatura > _limiteCritico)
   {
   OnTemperaturaCritica(temperatura);
  }
 }
   protected virtual void OnTemperaturaCritica(double temperaturaAtual)
 {
   TemperaturaCritica?.Invoke(this, new TemperaturaEventArgs(temperaturaAtual));
   }
  }
   class Program
 {
  static void Main(string[] args)
{
  double limiteCritico = 75.0;
   Sensor sensor = new Sensor(limiteCritico);
   sensor.TemperaturaCritica += Sensor_TemperaturaCritica;
    double[] leiturasDeTemperatura = { 67.1, 70.1, 76.1, 65.1 };
     foreach (var temperatura in leiturasDeTemperatura)
      {
   sensor.VerificarTemperatura(temperatura);
     }
   Console.ReadLine();
  }
   private static void Sensor_TemperaturaCritica(object sender, TemperaturaEventArgs e)
 {
   Console.WriteLine($"ALERTA: Temperatura crítica atingida! Valor atual: {e.TemperaturaAtual}°C");
   }
 }
}
