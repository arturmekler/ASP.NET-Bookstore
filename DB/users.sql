-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 22 Kwi 2019, 13:35
-- Wersja serwera: 10.1.36-MariaDB
-- Wersja PHP: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `ksiegarnia`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `idklienta` int(11) NOT NULL,
  `login` text COLLATE utf8_polish_ci NOT NULL,
  `haslo` text COLLATE utf8_polish_ci NOT NULL,
  `imie` text COLLATE utf8_polish_ci NOT NULL,
  `nazwisko` text COLLATE utf8_polish_ci NOT NULL,
  `miejscowosc` text COLLATE utf8_polish_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`idklienta`, `login`, `haslo`, `imie`, `nazwisko`, `miejscowosc`) VALUES
(1, 'lewandowski', 'lewandowski123', 'Łukasz', 'Lewandowski', 'Poznań'),
(2, 'nowak', 'nowak123', 'Jan', 'Nowak', 'Katowice'),
(3, 'kowalski', 'kowalski123', 'Maciej', 'Kowalski', 'Bydgoszcz'),
(4, 'psikuta', 'psikuta123', 'Agnieszka', 'Psikuta', 'Lublin'),
(5, 'mazur', 'mazur123', 'Tomasz', 'Mazur', 'Jelenia Góra'),
(6, 'zielinski', 'zielinski123', 'Michał', 'Zieliński', 'Kraków'),
(7, 'rutkowski', 'rutkowski123', 'Artur', 'Rutkowski', 'Kielce'),
(8, 'skorupa', 'skorupa123', 'Mateusz', 'Skorupa', 'Gdańsk'),
(9, 'rutkowski2', 'rutkowski1234', 'Jerzy', 'Rutkowski', 'Rybnik');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`idklienta`),
  ADD KEY `id` (`idklienta`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `users`
--
ALTER TABLE `users`
  MODIFY `idklienta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
