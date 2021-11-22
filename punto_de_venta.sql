-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 22, 2021 at 10:31 AM
-- Server version: 10.4.20-MariaDB
-- PHP Version: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `punto_de_venta`
--

-- --------------------------------------------------------

--
-- Table structure for table `productos`
--

CREATE TABLE `productos` (
  `id_producto` int(11) NOT NULL,
  `nombre_producto` varchar(64) NOT NULL,
  `precio` double(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `productos`
--

INSERT INTO `productos` (`id_producto`, `nombre_producto`, `precio`) VALUES
(1, 'Suavitel', 25.00),
(2, 'Gansito', 15.50),
(999, 'Chicle', 0.50),
(998, 'coca cola', 12.00),
(0, 'Sabritas', 15.00),
(3, 'Sabritas', 15.00),
(4, 'Sal', 20.00),
(5, 'Cafe en frasco', 15.00),
(6, 'Pan', 20.00),
(7, 'Jugo de manzana', 12.00),
(8, 'Yogurth de fresa', 13.00),
(9, 'Pastel de zanahoria', 50.00),
(10, 'Sopa de coditos', 15.00);

-- --------------------------------------------------------

--
-- Table structure for table `usuarios`
--

CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL,
  `nombre_usuario` varchar(64) NOT NULL,
  `apellido_usuario` varchar(64) NOT NULL,
  `password` varchar(64) NOT NULL,
  `permisosUsuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `usuarios`
--

INSERT INTO `usuarios` (`id_usuario`, `nombre_usuario`, `apellido_usuario`, `password`, `permisosUsuario`) VALUES
(2, 'Irak', 'Soqui', '1', 2),
(11, 'Humberto', 'Abril', '1', 2),
(14, 'Cesar', 'Solano', '1', 1),
(111, 'Luis', 'Moreno', '1', 1);

-- --------------------------------------------------------

--
-- Table structure for table `ventas`
--

CREATE TABLE `ventas` (
  `idventa` int(11) NOT NULL,
  `fechaventa` date NOT NULL,
  `horaventa` time NOT NULL,
  `operadorVenta` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ventas`
--

INSERT INTO `ventas` (`idventa`, `fechaventa`, `horaventa`, `operadorVenta`) VALUES
(1, '2021-11-04', '12:38:41', 1),
(2, '2021-11-04', '12:39:20', 1),
(3, '2021-11-04', '12:40:15', 2),
(5, '2021-11-09', '12:28:51', 1),
(6, '2021-11-09', '12:31:07', 1),
(7, '2021-11-11', '13:02:16', 1),
(8, '2021-11-11', '13:04:35', 1),
(9, '2021-11-22', '00:56:53', 14),
(10, '2021-11-22', '01:00:57', 1),
(11, '2021-11-22', '01:01:59', 1),
(12, '2021-11-22', '01:03:52', 1),
(13, '2021-11-22', '01:07:24', 14),
(14, '2021-11-22', '01:09:46', 14),
(15, '2021-11-22', '02:09:17', 111),
(16, '2021-11-22', '02:11:40', 111),
(17, '2021-11-22', '02:11:49', 111),
(18, '2021-11-22', '02:11:58', 111),
(19, '2021-11-22', '02:12:11', 111);

-- --------------------------------------------------------

--
-- Table structure for table `ventas_detalle`
--

CREATE TABLE `ventas_detalle` (
  `id_venta` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `precio_producto` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ventas_detalle`
--

INSERT INTO `ventas_detalle` (`id_venta`, `id_producto`, `cantidad`, `precio_producto`) VALUES
(5, 1, 1, 25),
(5, 2, 1, 15.5),
(6, 1, 3, 75),
(6, 2, 3, 46.5),
(6, 998, 1, 12),
(6, 999, 1, 0.5),
(7, 1, 1, 25),
(7, 2, 1, 15.5),
(7, 3, 1, 15),
(8, 4, 1, 20),
(8, 5, 1, 15),
(8, 6, 1, 20),
(9, 7, 1, 12),
(9, 8, 1, 13),
(9, 9, 1, 50),
(10, 10, 1, 15),
(10, 1, 1, 25),
(10, 2, 1, 15.5),
(11, 3, 1, 15),
(11, 4, 1, 20),
(11, 5, 1, 15),
(12, 6, 1, 20),
(12, 7, 1, 12),
(12, 8, 1, 13),
(13, 8, 1, 13),
(13, 9, 1, 50),
(13, 10, 1, 15),
(14, 1, 1, 25),
(14, 2, 1, 15.5),
(14, 3, 1, 15),
(15, 4, 1, 20),
(15, 5, 1, 15),
(15, 6, 1, 20),
(16, 7, 1, 12),
(16, 8, 1, 13),
(16, 9, 1, 50),
(17, 10, 1, 15),
(17, 1, 1, 25),
(17, 2, 1, 15.5),
(17, 3, 1, 15),
(18, 5, 1, 15),
(18, 6, 1, 20),
(18, 7, 1, 12),
(18, 8, 1, 13),
(18, 9, 1, 50),
(7, 2, 1, 15.5),
(8, 1, 1, 25),
(15, 5, 7, 105),
(15, 6, 1, 20),
(15, 3, 1, 15),
(15, 2, 2, 31),
(15, 1, 1, 25),
(15, 9, 4, 200),
(16, 4, 2, 40),
(17, 1, 1, 25),
(18, 9, 1, 50),
(19, 998, 1, 12),
(19, 1, 1, 25);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id_usuario`);

--
-- Indexes for table `ventas`
--
ALTER TABLE `ventas`
  ADD UNIQUE KEY `idventa` (`idventa`),
  ADD KEY `operadorVenta` (`operadorVenta`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id_usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=112;

--
-- AUTO_INCREMENT for table `ventas`
--
ALTER TABLE `ventas`
  MODIFY `idventa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
