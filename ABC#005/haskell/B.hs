main :: IO()
main = do
  line <- getLine
  ns <- readNum 0 (read line :: Int) []
  putStrLn $ show . minimum $ ns

readNum :: Int -> Int -> [Int] -> IO [Int]
readNum i n ns = do
  if (i < n) then
    do
      line <- getLine
      readNum (i + 1) n ((read line :: Int):ns)
  else
    return ns
