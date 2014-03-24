main :: IO()
main = do
  line <- getLine
  let ns = words line
  putStrLn $ show $ div (read (ns !! 1) :: Int) (read (ns !! 0) :: Int)
