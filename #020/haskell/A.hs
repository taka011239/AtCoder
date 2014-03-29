import Control.Applicative

main = do
  ab <- words <$> getLine
  judge (map (abs . read) ab :: [Int])

judge :: [Int] -> IO()
judge (a:b:[])
  | a < b = putStrLn "Ant"
  | a > b = putStrLn "Bug"
  | a == b  = putStrLn "Draw"
