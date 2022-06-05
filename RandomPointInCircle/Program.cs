public class Solution
{
    private double _radius { get; set; }
    private double _x_center { get; set; }
    private double _y_center { get; set; }
    public Solution(double radius, double x_center, double y_center)
    {
        _radius = radius;
        _x_center = x_center;
        _y_center = y_center;
    }

    public double[] RandPoint()
    {
        var theta = Math.PI * 2 * new Random().NextDouble();
        var k = random();
        var r = _radius * Math.Sqrt(k);
        var x = r * Math.Sin(theta);
        var y = r * Math.Cos(theta);
        return new double[] { x + _x_center, y + _y_center };
    }
    private double random()
    {
        var seed = Guid.NewGuid().GetHashCode();
        Random r = new Random(seed);
        int i = r.Next(0, 100000);
        return (double)i / 100000;
    }
}