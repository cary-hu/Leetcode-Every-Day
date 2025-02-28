/// <summary>
/// 20250228
/// https://leetcode.cn/problems/design-a-food-rating-system/
/// </summary>
public class FoodRatings
{
    private class FoodInfo
    {
        public string Cuisine { get; set; }
        public int Rating { get; set; }
        public FoodInfo(string cuisine, int rating)
        {
            Cuisine = cuisine;
            Rating = rating;
        }
    }

    private readonly Dictionary<string, SortedSet<(int Rating, string Food)>> cuisineRatings = new();
    private readonly Dictionary<string, FoodInfo> foodMap = new();

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        for (int i = 0; i < foods.Length; i++)
        {
            foodMap[foods[i]] = new FoodInfo(cuisines[i], ratings[i]);

            if (!cuisineRatings.TryGetValue(cuisines[i], out var set))
            {
                set = new SortedSet<(int Rating, string Food)>(Comparer<(int Rating, string Food)>.Create((a, b) =>
                {
                    if (a.Rating != b.Rating)
                        return b.Rating.CompareTo(a.Rating);
                    return a.Food.CompareTo(b.Food);
                }));
                cuisineRatings[cuisines[i]] = set;
            }

            set.Add((ratings[i], foods[i]));
        }
    }

    public void ChangeRating(string food, int newRating)
    {
        var info = foodMap[food];
        var set = cuisineRatings[info.Cuisine];

        set.Remove((info.Rating, food));
        info.Rating = newRating;
        set.Add((newRating, food));
    }

    public string HighestRated(string cuisine)
    {
        return cuisineRatings[cuisine].First().Food;
    }
}

/**
 * Your FoodRatings object will be instantiated and called as such:
 * FoodRatings obj = new FoodRatings(foods, cuisines, ratings);
 * obj.ChangeRating(food,newRating);
 * string param_2 = obj.HighestRated(cuisine);
 */