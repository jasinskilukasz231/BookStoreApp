-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 03 Lut 2023, 16:05
-- Wersja serwera: 10.4.24-MariaDB
-- Wersja PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `bookstore`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `books`
--

CREATE TABLE `books` (
  `id` int(11) NOT NULL,
  `title` text NOT NULL,
  `displayTitle` text NOT NULL,
  `autor` text NOT NULL,
  `year` year(4) NOT NULL,
  `nr_pages` int(11) NOT NULL,
  `price` double NOT NULL,
  `possible_to_loan` tinyint(1) NOT NULL,
  `booksAvailable` text NOT NULL,
  `imageName` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `books`
--

INSERT INTO `books` (`id`, `title`, `displayTitle`, `autor`, `year`, `nr_pages`, `price`, `possible_to_loan`, `booksAvailable`, `imageName`) VALUES
(1, 'salems lot', 'Salem\'s Lot', 'Stephen King', 2018, 525, 10, 1, '2', 'salems_lot.png'),
(2, 'the da vinci code', 'The Da Vinci Code', 'Dan Brown', 2022, 592, 16.99, 1, '1', 'the_davinci_code.png'),
(3, 'the godfather', 'The Godfather', 'Mario Puzo', 2022, 576, 12.49, 0, '0', 'the_godfather.png');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `books_tags`
--

CREATE TABLE `books_tags` (
  `id` int(11) NOT NULL,
  `id_tag` int(11) NOT NULL,
  `id_book` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `books_tags`
--

INSERT INTO `books_tags` (`id`, `id_tag`, `id_book`) VALUES
(1, 1, 2),
(2, 2, 2),
(3, 3, 2),
(4, 4, 2),
(5, 5, 2),
(6, 6, 2),
(7, 7, 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `customers_data`
--

CREATE TABLE `customers_data` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `last_name` text NOT NULL,
  `email` text NOT NULL,
  `phone` text NOT NULL,
  `address` text NOT NULL,
  `sex` text NOT NULL,
  `login` text NOT NULL,
  `password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `customers_data`
--

INSERT INTO `customers_data` (`id`, `name`, `last_name`, `email`, `phone`, `address`, `sex`, `login`, `password`) VALUES
(1, 'Lukasz', 'Jasinski', 'jasinskilukasz231@gmail.com', '668918490', 'Trzciniec 168 28-362 Naglowice', 'Man', 'lukasz52201', 'JestemLukasz123'),
(2, 'Jan', 'Sobieski', 'janekS12@gmail.com', '559183291', 'Wolska 13/2 00-001 Warszawa', 'Man', 'Janek123', 'TakieHaslo12'),
(3, 'Tom', 'Hardy', 'thooomas69@onet.pl', '559829889', 'Hollywood', 'Man', 'Thoomas12', 'HardyHard12'),
(4, 'Kasia', 'Treter', 'Kasiula12@gmail.com', '558918293', 'ul. Strzody 8/1 28-300 Gliwice', 'NULL', 'logintaki123', 'TakieHasllo123'),
(5, 'Sebastian', 'Kowal', 'kowalll@gmail.com', '559918339', 'ul. Kwiatowa 15 25-321 Lodz', 'Different', 'sebastianeek12', 'KowalSeba13'),
(6, 'Krzysztof', 'Karasinski', 'krzykar123@wp.pl', '582918392', 'Piaskowa 4 28-301 Knurow', 'Man', 'krzykar890', 'TakieHasloJaki1'),
(7, 'Pawel', 'Tomczyk', 'pawlo5220@wp.pl', '223332221', 'Jana Pawla 2 3, 28-362 Naglowice', 'Man', 'fajnyLoggingg123', 'Kwiatek123'),
(8, 'Gracjan', 'Roztocki', 'roztocki123@wp.pl', '666999666', 'Internet', 'Different', 'gracJJan123', 'LubieKUpe123'),
(9, 'Emilia', 'Jasinska', 'kontodowota80@wp.pl', '668918390', 'Trzciniec 168 28-362 Naglowice', 'Woman', 'emiJas123', 'jestemEmila12'),
(10, 'Jack', 'Kowalsky', 'helloMan99@wp.pl', '682918392', 'Brooklyn 28/2', 'Man', 'kowAALsky123', 'WindowIAm123'),
(11, 'Jisoo', 'Kim', 'JissooYaa@gamil.pl', '889889221', 'Seoul/Heaven', 'Woman', 'JisooTurtle123', 'RabbitKim778'),
(12, 'Marek', 'Towarek', 'mareczek69@gmail.com', '112332112', 'Jakas wies gdzies tam', 'NULL', 'marektowarek13', 'towareKKmam121'),
(13, 'Jack', 'Nicolson', 'jackiee12@onet.pl', '559918293', 'Hollywood', 'NULL', 'lukasz5220111', 'Wiedzmin13'),
(14, 'Jan', 'Kaczmarek', 'KaczkaDziwaczka@o2.pl', '123998291', 'Lipowa 13, 28-312 Oksa', 'Different', 'kaczor13', 'Komornik13'),
(15, 'Genowefa', 'Pigwa', 'gienia@wp.pl', '332666221', 'Address gdzies tam', 'Different', 'Gienia997', 'Gienia997'),
(16, 'Jennie', 'Kim', 'doukieJen@gmail.com', '112991992', 'Seoul, Sout Korea', 'Woman', 'Manduu2291', 'LoveJennie112'),
(17, 'Jennie', 'Kim', 'JennieLove@gmail.com', '112991992', 'Seoul, Sout Korea', 'Woman', 'IamJennie221', 'LoveJennie112'),
(18, 'Emilia', 'Jasińska', 'gdyuyyg@gmail.com', '556222583', 'warszawa', 'Woman', 'emiliajasinska', 'zupa123'),
(19, 'Emilia', 'Jasińska', 'gdyuyyg@gmail.com', '556222583', 'warszawa', 'Woman', 'emiliajasinska80', 'zupa123'),
(20, 'Emilia', 'Jasińska', 'gdyuyyg@gmail.com', '556222583', 'warszawa', 'Woman', 'emilia80', 'zupa123'),
(21, 'Emilia', 'Jasińska', 'gdyuyyg@gmail.com', '556222583', 'warszawa', 'Woman', 'emilia80_', 'zupa123'),
(22, 'Karolina', 'Nowak', 'nowak420@wp.pl', '666666991', 'Gdansk, jakas ulica', 'Woman', 'Karolina', 'haslo'),
(23, 'Karolina', 'Nowak', 'nowak420@wp.pl', '666666991', 'Gdansk, jakas ulica', 'Woman', 'Karolina123', 'Haslo123'),
(24, 'Karol', 'Krawczyk', 'karolKrawczyk@gmail.com', '339200291', 'Wolska 12/33 Warszawa', 'Man', 'Karol123', 'Karolek123'),
(25, 'Jaś', 'Kapela', 'email@wp.pl', '123456786', 'gdzies tam', 'Other', 'logintaki1234', 'haselkoo'),
(26, 'Tymek', 'Kocioł', 'emila@gmail.com', '123123123', 'Trzciniec', 'Man', 'emilia801', 'hasloJakies'),
(27, 'Thomas', 'Smith', 'smithTHomas@gmail.com', '229118821', 'Wisconsin', 'Man', 'Janek1234', 'HasloMaslo123'),
(28, 'Thomas', 'Smith', 'smithTHomas@gmail.com', '229118821', 'Wisconsin', 'Man', 'Janek123411', 'HasloMaslo123'),
(29, 'Konrad', 'Paweł', 'kondzio@o2.pl', '228918920', 'Address Moj jakis', 'Other', 'Janek123342', 'Ladowarka123'),
(30, 'Martha', 'Smith', 'myEmail23@o2.pl', '112221221', 'Tokio', 'Man', 'kaczor1312', 'MyPassword123'),
(31, 'asdasd', 'asdasd', 'asdasd', 'asdasd', 'asdasd', 'Man', 'asdasdasd', 'asdasd'),
(32, 'asdad', 'asdasd', 'asdasd', 'asdasd', 'asdasd', 'Man', 'asdasd', 'asdasda'),
(33, 'sda', 'asd', 'asdasd', 'asd', 'asdasd', 'Man', 'sebastianeek121', 'asdasdasd'),
(34, 'Kazimierz', 'Polski', 'polak@yahoo.com', '229919229', 'Kobierzyn 13/5', 'Other', 'Kazik12', 'PolakToJa123'),
(35, 'Paweł', 'Kaczmarek', 'pawelek23@wp.pl', '229918339', 'Jana Pawła 3/5 28-362 Nagłowice', 'Man', 'pawełGaweł123', 'Drzewo123'),
(36, 'Kacper', 'Mularczyk', 'Kacpi90@gmail.com', '992991882', 'Sosnowiec', 'Man', 'kackij123', 'Mularczyk992');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `customers_preferences`
--

CREATE TABLE `customers_preferences` (
  `id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `id_book_in_cart` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `loans`
--

CREATE TABLE `loans` (
  `id` int(11) NOT NULL,
  `id_customer` int(11) NOT NULL,
  `id_book` int(11) NOT NULL,
  `date_loan` date NOT NULL,
  `date_return` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `loans`
--

INSERT INTO `loans` (`id`, `id_customer`, `id_book`, `date_loan`, `date_return`) VALUES
(1, 1, 2, '2023-01-12', '2023-04-12');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `orders`
--

CREATE TABLE `orders` (
  `id` int(11) NOT NULL,
  `id_customer` int(11) NOT NULL,
  `id_book` int(11) NOT NULL,
  `date` date NOT NULL,
  `status` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `orders`
--

INSERT INTO `orders` (`id`, `id_customer`, `id_book`, `date`, `status`) VALUES
(1, 1, 1, '2023-01-12', 'payd');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `tag_name`
--

CREATE TABLE `tag_name` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `tag_name`
--

INSERT INTO `tag_name` (`id`, `name`) VALUES
(1, 'literatura_wspolczesna\r\n'),
(2, 'literatura_amerykanska'),
(3, 'xxi_wiek'),
(4, 'muzeum'),
(5, 'morderstwo'),
(6, 'symbol'),
(7, 'tajemnica');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `books_tags`
--
ALTER TABLE `books_tags`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `customers_data`
--
ALTER TABLE `customers_data`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `customers_preferences`
--
ALTER TABLE `customers_preferences`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `loans`
--
ALTER TABLE `loans`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `tag_name`
--
ALTER TABLE `tag_name`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `books`
--
ALTER TABLE `books`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `books_tags`
--
ALTER TABLE `books_tags`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT dla tabeli `customers_data`
--
ALTER TABLE `customers_data`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT dla tabeli `customers_preferences`
--
ALTER TABLE `customers_preferences`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT dla tabeli `loans`
--
ALTER TABLE `loans`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `orders`
--
ALTER TABLE `orders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `tag_name`
--
ALTER TABLE `tag_name`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
