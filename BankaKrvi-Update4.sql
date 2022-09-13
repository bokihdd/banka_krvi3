-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 12, 2022 at 05:14 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bankakrvi`
--

-- --------------------------------------------------------

--
-- Table structure for table `donacija`
--

CREATE TABLE `donacija` (
  `idDonacije` int(11) NOT NULL,
  `Donor` int(11) NOT NULL,
  `Pacijent` int(11) NOT NULL,
  `DatumPreuzimanja` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `donacija`
--

INSERT INTO `donacija` (`idDonacije`, `Donor`, `Pacijent`, `DatumPreuzimanja`) VALUES
(1, 1, 1, '2022-09-20');

-- --------------------------------------------------------

--
-- Table structure for table `donor`
--

CREATE TABLE `donor` (
  `idDonor` int(5) NOT NULL,
  `Ime` varchar(50) NOT NULL,
  `Prezime` varchar(50) NOT NULL,
  `GodinaRodjenja` year(4) NOT NULL,
  `DatumDoniranja` date NOT NULL,
  `KrvnaGrupa` varchar(20) NOT NULL,
  `KolicinaKrvi` mediumint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `donor`
--

INSERT INTO `donor` (`idDonor`, `Ime`, `Prezime`, `GodinaRodjenja`, `DatumDoniranja`, `KrvnaGrupa`, `KolicinaKrvi`) VALUES
(1, 'Pera', 'Peric', 2000, '2022-09-14', 'A+', 500),
(2, 'Zika', 'Zikic', 2005, '2022-09-27', 'A+', 300),
(3, 'Boris', 'Brajkov', 2000, '2022-09-15', 'B+', 200);

-- --------------------------------------------------------

--
-- Table structure for table `inventar`
--

CREATE TABLE `inventar` (
  `idInventara` int(11) NOT NULL,
  `Donor` int(11) NOT NULL,
  `Donirano` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `inventar`
--

INSERT INTO `inventar` (`idInventara`, `Donor`, `Donirano`) VALUES
(1, 1, 1),
(2, 2, NULL),
(3, 3, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `korisnik`
--

CREATE TABLE `korisnik` (
  `idKorisnik` int(5) NOT NULL,
  `Ime` varchar(50) NOT NULL,
  `Prezime` varchar(30) NOT NULL,
  `DatumRodjenja` date NOT NULL,
  `Email` varchar(80) NOT NULL,
  `KorisnickoIme` varchar(100) NOT NULL,
  `Sifra` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `pacijent`
--

CREATE TABLE `pacijent` (
  `idPacijenta` int(5) NOT NULL,
  `Ime` varchar(50) NOT NULL,
  `Prezime` varchar(50) NOT NULL,
  `GodinaRodjenja` year(4) NOT NULL,
  `KrvnaGrupa` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pacijent`
--

INSERT INTO `pacijent` (`idPacijenta`, `Ime`, `Prezime`, `GodinaRodjenja`, `KrvnaGrupa`) VALUES
(1, 'Mica', 'Peric', 2000, 'B+');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `donacija`
--
ALTER TABLE `donacija`
  ADD PRIMARY KEY (`idDonacije`),
  ADD KEY `Donor` (`Donor`),
  ADD KEY `Pacijent` (`Pacijent`);

--
-- Indexes for table `donor`
--
ALTER TABLE `donor`
  ADD PRIMARY KEY (`idDonor`);

--
-- Indexes for table `inventar`
--
ALTER TABLE `inventar`
  ADD PRIMARY KEY (`idInventara`),
  ADD UNIQUE KEY `Donor` (`Donor`) USING BTREE,
  ADD KEY `Donirano` (`Donirano`);

--
-- Indexes for table `korisnik`
--
ALTER TABLE `korisnik`
  ADD PRIMARY KEY (`idKorisnik`);

--
-- Indexes for table `pacijent`
--
ALTER TABLE `pacijent`
  ADD PRIMARY KEY (`idPacijenta`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `donacija`
--
ALTER TABLE `donacija`
  ADD CONSTRAINT `donacija_ibfk_1` FOREIGN KEY (`Pacijent`) REFERENCES `pacijent` (`idPacijenta`),
  ADD CONSTRAINT `donacija_ibfk_2` FOREIGN KEY (`Donor`) REFERENCES `donor` (`idDonor`);

--
-- Constraints for table `inventar`
--
ALTER TABLE `inventar`
  ADD CONSTRAINT `inventar_ibfk_1` FOREIGN KEY (`Donor`) REFERENCES `donor` (`idDonor`),
  ADD CONSTRAINT `inventar_ibfk_2` FOREIGN KEY (`Donirano`) REFERENCES `donacija` (`idDonacije`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
