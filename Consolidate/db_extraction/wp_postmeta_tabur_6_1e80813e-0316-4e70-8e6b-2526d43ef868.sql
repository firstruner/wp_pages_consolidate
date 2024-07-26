-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : lun. 01 juil. 2024 à 14:30
-- Version du serveur : 8.3.0
-- Version de PHP : 8.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `convergence`
--

-- --------------------------------------------------------

--
-- Structure de la table `wp_postmeta`
--

CREATE TABLE IF NOT EXISTS `wp_postmeta` (
  `meta_id` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  `post_id` bigint UNSIGNED NOT NULL DEFAULT '0',
  `meta_key` varchar(255) COLLATE utf8mb4_unicode_520_ci DEFAULT NULL,
  `meta_value` longtext COLLATE utf8mb4_unicode_520_ci,
  PRIMARY KEY (`meta_id`),
  KEY `post_id` (`post_id`),
  KEY `meta_key` (`meta_key`(191))
) ENGINE=InnoDB AUTO_INCREMENT=2234 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_520_ci;

--
-- Déchargement des données de la table `wp_postmeta`
--


INSERT INTO wp_postmeta (meta_id, post_id, meta_key, meta_value) VALUES
(2128, 393, '_elementor_css', 'a:6:{s:4:\"time\";i:1718805917;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2129, 394, '_elementor_edit_mode', 'builder'),
(2130, 394, '_elementor_template_type', 'wp-page'),
(2131, 394, '_elementor_version', '3.18.3'),
(2132, 394, '_wp_page_template', 'default'),
(2133, 394, '_elementor_data', '[{\"id\":\"5e28a44\",\"elType\":\"container\",\"settings\":[],\"elements\":[{\"id\":\"e63a0eb\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_usermanager]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false}]'),
(2134, 394, '_elementor_page_assets', 'a:0:{}'),
(2135, 394, '_elementor_css', 'a:6:{s:4:\"time\";i:1718805917;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2136, 395, '_elementor_edit_mode', 'builder'),
(2137, 395, '_elementor_template_type', 'wp-page'),
(2138, 395, '_elementor_version', '3.18.3'),
(2139, 395, '_wp_page_template', 'default'),
(2140, 395, '_elementor_data', '[{\"id\":\"5e28a44\",\"elType\":\"container\",\"settings\":[],\"elements\":[{\"id\":\"e63a0eb\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_userManager]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false}]'),
(2141, 395, '_elementor_page_assets', 'a:0:{}'),
(2142, 395, '_elementor_css', 'a:6:{s:4:\"time\";i:1718805917;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2143, 388, '_elementor_css', 'a:6:{s:4:\"time\";i:1718899798;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2144, 396, '_wp_page_template', 'elementor_header_footer'),
(2145, 396, '_elementor_edit_mode', 'builder'),
(2146, 396, '_elementor_template_type', 'wp-page'),
(2147, 396, '_elementor_version', '3.18.3'),
(2148, 396, '_elementor_data', '[{\"id\":\"7f5fdde\",\"elType\":\"container\",\"settings\":[],\"elements\":[{\"id\":\"ec4ac46\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_LevelRequire group=salary min_level=1]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false},{\"id\":\"16ef585\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"row\",\"flex_gap\":{\"unit\":\"px\",\"size\":0,\"column\":\"0\",\"row\":\"0\"}},\"elements\":[{\"id\":\"753ea4d\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":\"33.3333\"}},\"elements\":[{\"id\":\"98ecedb\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[LastRHEvents]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":true},{\"id\":\"0b54fcb\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":\"66.6666\"}},\"elements\":[{\"id\":\"2374a6a\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[RDV_Reminder]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":true}],\"isInner\":false},{\"id\":\"1ed170f\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"flex_justify_content\":\"center\",\"_flex_align_self\":\"center\"},\"elements\":[{\"id\":\"6b9ce19\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[Slides group=salary]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false},{\"id\":\"11b43b9\",\"elType\":\"container\",\"settings\":{\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":99.555},\"flex_align_items\":\"flex-start\",\"_flex_size\":\"none\",\"_element_width\":\"initial\"},\"elements\":[{\"id\":\"93fc5f2\",\"elType\":\"widget\",\"settings\":{\"title\":\"Supervisor \",\"link\":{\"url\":\"http:\\/\\/localhost\\/convergence\\/Website\\/Convergence\\/supervisor-menu\",\"is_external\":\"\",\"nofollow\":\"\",\"custom_attributes\":\"\"},\"header_size\":\"h4\"},\"elements\":[],\"widgetType\":\"heading\"},{\"id\":\"afeb903\",\"elType\":\"widget\",\"settings\":{\"title\":\"Manager\",\"link\":{\"url\":\"http:\\/\\/localhost\\/convergence\\/Website\\/Convergence\\/manager-menu\",\"is_external\":\"\",\"nofollow\":\"\",\"custom_attributes\":\"\"},\"header_size\":\"h4\"},\"elements\":[],\"widgetType\":\"heading\"}],\"isInner\":false}]'),
(2149, 396, '_elementor_page_assets', 'a:0:{}'),
(2150, 396, '_elementor_css', 'a:6:{s:4:\"time\";i:1718799107;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2151, 397, '_wp_page_template', 'elementor_header_footer'),
(2152, 397, '_elementor_edit_mode', 'builder'),
(2153, 397, '_elementor_template_type', 'wp-page'),
(2154, 397, '_elementor_version', '3.18.3'),
(2155, 397, '_elementor_data', '[{\"id\":\"7f5fdde\",\"elType\":\"container\",\"settings\":[],\"elements\":[{\"id\":\"ec4ac46\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_LevelRequire group=salary min_level=1]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false},{\"id\":\"16ef585\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"row\",\"flex_gap\":{\"unit\":\"px\",\"size\":0,\"column\":\"0\",\"row\":\"0\"}},\"elements\":[{\"id\":\"753ea4d\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":\"33.3333\"}},\"elements\":[{\"id\":\"98ecedb\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[LastRHEvents]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":true},{\"id\":\"0b54fcb\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":\"66.6666\"}},\"elements\":[{\"id\":\"2374a6a\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[RDV_Reminder]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":true}],\"isInner\":false},{\"id\":\"1ed170f\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"flex_justify_content\":\"center\",\"_flex_align_self\":\"center\"},\"elements\":[{\"id\":\"6b9ce19\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[Slides group=salary]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false},{\"id\":\"11b43b9\",\"elType\":\"container\",\"settings\":{\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":99.555},\"flex_align_items\":\"flex-start\",\"_flex_size\":\"none\",\"_element_width\":\"initial\"},\"elements\":[{\"id\":\"93fc5f2\",\"elType\":\"widget\",\"settings\":{\"title\":\"Supervisor \",\"link\":{\"url\":\"http:\\/\\/localhost\\/convergence\\/Website\\/Convergence\\/supervisor-menu\",\"is_external\":\"\",\"nofollow\":\"\",\"custom_attributes\":\"\"},\"header_size\":\"h4\"},\"elements\":[],\"widgetType\":\"heading\"},{\"id\":\"afeb903\",\"elType\":\"widget\",\"settings\":{\"title\":\"Manager\",\"link\":{\"url\":\"http:\\/\\/localhost\\/convergence\\/Website\\/Convergence\\/manager-menu\",\"is_external\":\"\",\"nofollow\":\"\",\"custom_attributes\":\"\"},\"header_size\":\"h4\"},\"elements\":[],\"widgetType\":\"heading\"}],\"isInner\":false}]'),
(2156, 397, '_elementor_page_assets', 'a:0:{}'),
(2157, 397, '_elementor_css', 'a:6:{s:4:\"time\";i:1718799107;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2158, 398, '_wp_page_template', 'elementor_header_footer'),
(2159, 398, '_elementor_edit_mode', 'builder'),
(2160, 398, '_elementor_template_type', 'wp-page'),
(2161, 398, '_elementor_version', '3.18.3'),
(2162, 398, '_elementor_data', '[{\"id\":\"7f5fdde\",\"elType\":\"container\",\"settings\":[],\"elements\":[{\"id\":\"ec4ac46\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_LevelRequire group=salary min_level=1]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false},{\"id\":\"16ef585\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"row\",\"flex_gap\":{\"unit\":\"px\",\"size\":0,\"column\":\"0\",\"row\":\"0\"}},\"elements\":[{\"id\":\"753ea4d\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":\"33.3333\"}},\"elements\":[{\"id\":\"98ecedb\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[LastRHEvents]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":true},{\"id\":\"0b54fcb\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":\"66.6666\"}},\"elements\":[{\"id\":\"2374a6a\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[RDV_Reminder]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":true}],\"isInner\":false},{\"id\":\"1ed170f\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"flex_justify_content\":\"center\",\"_flex_align_self\":\"center\"},\"elements\":[{\"id\":\"6b9ce19\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[Slides group=salary]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false},{\"id\":\"11b43b9\",\"elType\":\"container\",\"settings\":{\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":99.555},\"flex_align_items\":\"flex-start\",\"_flex_size\":\"none\",\"_element_width\":\"initial\"},\"elements\":[{\"id\":\"f2aec95\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_roleMenuButtons]\"},\"elements\":[],\"widgetType\":\"shortcode\"},{\"id\":\"93fc5f2\",\"elType\":\"widget\",\"settings\":{\"title\":\"Supervisor \",\"link\":{\"url\":\"http:\\/\\/localhost\\/convergence\\/Website\\/Convergence\\/supervisor-menu\",\"is_external\":\"\",\"nofollow\":\"\",\"custom_attributes\":\"\"},\"header_size\":\"h4\"},\"elements\":[],\"widgetType\":\"heading\"},{\"id\":\"afeb903\",\"elType\":\"widget\",\"settings\":{\"title\":\"Manager\",\"link\":{\"url\":\"http:\\/\\/localhost\\/convergence\\/Website\\/Convergence\\/manager-menu\",\"is_external\":\"\",\"nofollow\":\"\",\"custom_attributes\":\"\"},\"header_size\":\"h4\"},\"elements\":[],\"widgetType\":\"heading\"}],\"isInner\":false}]'),
(2163, 398, '_elementor_page_assets', 'a:0:{}'),
(2164, 398, '_elementor_css', 'a:6:{s:4:\"time\";i:1718799107;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2166, 399, '_wp_page_template', 'elementor_header_footer'),
(2167, 399, '_elementor_edit_mode', 'builder'),
(2168, 399, '_elementor_template_type', 'wp-page'),
(2169, 399, '_elementor_version', '3.18.3'),
(2170, 399, '_elementor_data', '[{\"id\":\"7f5fdde\",\"elType\":\"container\",\"settings\":[],\"elements\":[{\"id\":\"ec4ac46\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_LevelRequire group=salary min_level=1]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false},{\"id\":\"16ef585\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"row\",\"flex_gap\":{\"unit\":\"px\",\"size\":0,\"column\":\"0\",\"row\":\"0\"}},\"elements\":[{\"id\":\"753ea4d\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":\"33.3333\"}},\"elements\":[{\"id\":\"98ecedb\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[LastRHEvents]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":true},{\"id\":\"0b54fcb\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":\"66.6666\"}},\"elements\":[{\"id\":\"2374a6a\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[RDV_Reminder]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":true}],\"isInner\":false},{\"id\":\"1ed170f\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"flex_justify_content\":\"center\",\"_flex_align_self\":\"center\"},\"elements\":[{\"id\":\"6b9ce19\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[Slides group=salary]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false},{\"id\":\"11b43b9\",\"elType\":\"container\",\"settings\":{\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":99.555},\"flex_align_items\":\"flex-start\",\"_flex_size\":\"none\",\"_element_width\":\"initial\"},\"elements\":[{\"id\":\"f2aec95\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_roleMenuButtons]\"},\"elements\":[],\"widgetType\":\"shortcode\"},{\"id\":\"93fc5f2\",\"elType\":\"widget\",\"settings\":{\"title\":\"Supervisor \",\"link\":{\"url\":\"http:\\/\\/localhost\\/convergence\\/Website\\/Convergence\\/supervisor-menu\",\"is_external\":\"\",\"nofollow\":\"\",\"custom_attributes\":\"\"},\"header_size\":\"h4\"},\"elements\":[],\"widgetType\":\"heading\"},{\"id\":\"afeb903\",\"elType\":\"widget\",\"settings\":{\"title\":\"Manager\",\"link\":{\"url\":\"http:\\/\\/localhost\\/convergence\\/Website\\/Convergence\\/manager-menu\",\"is_external\":\"\",\"nofollow\":\"\",\"custom_attributes\":\"\"},\"header_size\":\"h4\"},\"elements\":[],\"widgetType\":\"heading\"}],\"isInner\":false}]'),
(2171, 399, '_elementor_page_assets', 'a:0:{}'),
(2172, 399, '_elementor_css', 'a:6:{s:4:\"time\";i:1718899906;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2173, 400, '_wp_page_template', 'elementor_header_footer'),
(2174, 400, '_elementor_edit_mode', 'builder'),
(2175, 400, '_elementor_template_type', 'wp-page'),
(2176, 400, '_elementor_version', '3.18.3'),
(2177, 400, '_elementor_data', '[{\"id\":\"7f5fdde\",\"elType\":\"container\",\"settings\":[],\"elements\":[{\"id\":\"ec4ac46\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_LevelRequire group=salary min_level=1]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false},{\"id\":\"16ef585\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"row\",\"flex_gap\":{\"unit\":\"px\",\"size\":0,\"column\":\"0\",\"row\":\"0\"}},\"elements\":[{\"id\":\"753ea4d\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":\"33.3333\"}},\"elements\":[{\"id\":\"98ecedb\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[LastRHEvents]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":true},{\"id\":\"0b54fcb\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":\"66.6666\"}},\"elements\":[{\"id\":\"2374a6a\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[RDV_Reminder]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":true}],\"isInner\":false},{\"id\":\"1ed170f\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"flex_justify_content\":\"center\",\"_flex_align_self\":\"center\"},\"elements\":[{\"id\":\"6b9ce19\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[Slides group=salary]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false},{\"id\":\"11b43b9\",\"elType\":\"container\",\"settings\":{\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":99.555},\"flex_align_items\":\"flex-start\",\"_flex_size\":\"none\",\"_element_width\":\"initial\"},\"elements\":[{\"id\":\"f2aec95\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_roleMenuButtons]\"},\"elements\":[],\"widgetType\":\"shortcode\"},{\"id\":\"93fc5f2\",\"elType\":\"widget\",\"settings\":{\"title\":\"Supervisor \",\"link\":{\"url\":\"http:\\/\\/localhost\\/convergence\\/Website\\/Convergence\\/supervisor-menu\",\"is_external\":\"\",\"nofollow\":\"\",\"custom_attributes\":\"\"},\"header_size\":\"h4\"},\"elements\":[],\"widgetType\":\"heading\"},{\"id\":\"afeb903\",\"elType\":\"widget\",\"settings\":{\"title\":\"Manager\",\"link\":{\"url\":\"http:\\/\\/localhost\\/convergence\\/Website\\/Convergence\\/manager-menu\",\"is_external\":\"\",\"nofollow\":\"\",\"custom_attributes\":\"\"},\"header_size\":\"h4\"},\"elements\":[],\"widgetType\":\"heading\"}],\"isInner\":false}]'),
(2178, 400, '_elementor_page_assets', 'a:0:{}'),
(2179, 400, '_elementor_css', 'a:6:{s:4:\"time\";i:1718899906;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2180, 401, '_wp_page_template', 'elementor_header_footer'),
(2181, 401, '_elementor_edit_mode', 'builder'),
(2182, 401, '_elementor_template_type', 'wp-page'),
(2183, 401, '_elementor_version', '3.18.3'),
(2184, 401, '_elementor_data', '[{\"id\":\"7f5fdde\",\"elType\":\"container\",\"settings\":[],\"elements\":[{\"id\":\"ec4ac46\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_LevelRequire group=salary min_level=1]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false},{\"id\":\"16ef585\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"row\",\"flex_gap\":{\"unit\":\"px\",\"size\":0,\"column\":\"0\",\"row\":\"0\"}},\"elements\":[{\"id\":\"753ea4d\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":\"33.3333\"}},\"elements\":[{\"id\":\"98ecedb\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[LastRHEvents]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":true},{\"id\":\"0b54fcb\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":\"66.6666\"}},\"elements\":[{\"id\":\"2374a6a\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[RDV_Reminder]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":true}],\"isInner\":false},{\"id\":\"1ed170f\",\"elType\":\"container\",\"settings\":{\"flex_direction\":\"column\",\"flex_justify_content\":\"center\",\"_flex_align_self\":\"center\"},\"elements\":[{\"id\":\"6b9ce19\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[Slides group=salary]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false},{\"id\":\"11b43b9\",\"elType\":\"container\",\"settings\":{\"content_width\":\"full\",\"width\":{\"unit\":\"%\",\"size\":99.555},\"flex_align_items\":\"flex-start\",\"_flex_size\":\"none\",\"_element_width\":\"initial\"},\"elements\":[{\"id\":\"f2aec95\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_roleMenuButtons]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false}]'),
(2185, 401, '_elementor_page_assets', 'a:0:{}'),
(2186, 401, '_elementor_css', 'a:6:{s:4:\"time\";i:1718899906;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2187, 24, '_elementor_css', 'a:6:{s:4:\"time\";i:1718902753;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2188, 402, '_elementor_edit_mode', 'builder'),
(2189, 402, '_elementor_template_type', 'wp-page'),
(2190, 402, '_elementor_version', '3.18.3'),
(2191, 402, '_wp_page_template', 'default'),
(2192, 402, '_elementor_data', '[{\"id\":\"5e28a44\",\"elType\":\"container\",\"settings\":[],\"elements\":[{\"id\":\"e63a0eb\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_userManager]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false}]'),
(2193, 402, '_elementor_page_assets', 'a:0:{}'),
(2194, 402, '_elementor_css', 'a:6:{s:4:\"time\";i:1718899798;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2195, 403, '_edit_lock', '1719396655:1'),
(2196, 403, '_edit_last', 1),
(2197, 403, '_elementor_edit_mode', 'builder'),
(2198, 403, '_elementor_template_type', 'wp-page'),
(2199, 403, '_elementor_version', '3.18.3'),
(2200, 403, '_wp_page_template', 'default'),
(2201, 403, '_elementor_data', '[{\"id\":\"259a83c\",\"elType\":\"container\",\"settings\":[],\"elements\":[{\"id\":\"1b9e185\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_updateUser]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false}]'),
(2202, 403, '_elementor_page_assets', 'a:0:{}'),
(2204, 405, '_elementor_edit_mode', 'builder'),
(2205, 405, '_elementor_template_type', 'wp-page'),
(2206, 405, '_elementor_version', '3.18.3'),
(2207, 405, '_wp_page_template', 'default'),
(2208, 405, '_elementor_data', '[{\"id\":\"259a83c\",\"elType\":\"container\",\"settings\":[],\"elements\":[{\"id\":\"1b9e185\",\"elType\":\"widget\",\"settings\":[],\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false}]'),
(2209, 405, '_elementor_page_assets', 'a:0:{}'),
(2210, 405, '_elementor_css', 'a:6:{s:4:\"time\";i:1719396377;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2211, 406, '_elementor_edit_mode', 'builder'),
(2212, 406, '_elementor_template_type', 'wp-page'),
(2213, 406, '_elementor_version', '3.18.3'),
(2214, 406, '_wp_page_template', 'default'),
(2215, 406, '_elementor_data', '[{\"id\":\"259a83c\",\"elType\":\"container\",\"settings\":[],\"elements\":[{\"id\":\"1b9e185\",\"elType\":\"widget\",\"settings\":[],\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false}]'),
(2216, 406, '_elementor_page_assets', 'a:0:{}'),
(2217, 406, '_elementor_css', 'a:6:{s:4:\"time\";i:1719396377;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2218, 407, '_elementor_edit_mode', 'builder'),
(2219, 407, '_elementor_template_type', 'wp-page'),
(2220, 407, '_elementor_version', '3.18.3'),
(2221, 407, '_wp_page_template', 'default'),
(2222, 407, '_elementor_data', '[{\"id\":\"259a83c\",\"elType\":\"container\",\"settings\":[],\"elements\":[{\"id\":\"1b9e185\",\"elType\":\"widget\",\"settings\":{\"shortcode\":\"[crm_updateUser]\"},\"elements\":[],\"widgetType\":\"shortcode\"}],\"isInner\":false}]'),
(2223, 407, '_elementor_page_assets', 'a:0:{}'),
(2224, 407, '_elementor_css', 'a:6:{s:4:\"time\";i:1719396377;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}'),
(2225, 403, '_elementor_css', 'a:6:{s:4:\"time\";i:1719396406;s:5:\"fonts\";a:0:{}s:5:\"icons\";a:0:{}s:20:\"dynamic_elements_ids\";a:0:{}s:6:\"status\";s:4:\"file\";i:0;s:0:\"\";}');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;