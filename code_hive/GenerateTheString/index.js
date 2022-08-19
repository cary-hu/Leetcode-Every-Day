/**
 * @param {number} n
 * 20220801
 * https://leetcode.cn/problems/generate-a-string-with-characters-that-have-odd-counts/
 * @return {string}
 */
var generateTheString = function (n) {
  if (n % 2 === 0) {
    return "a".repeat(n - 1) + "b";
  } else {
    return "a".repeat(n);
  }
};
