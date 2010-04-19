﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using com.jds.GUpdater.classes.language.enums;
using com.jds.GUpdater.classes.language.properties;
using com.jds.GUpdater.classes.listloader;
using com.jds.GUpdater.classes.listloader.enums;
using com.jds.GUpdater.classes.registry;
using com.jds.GUpdater.classes.task_manager.tasks;

namespace com.jds.GUpdater.classes.games.propertyes
{
    /// <summary>
    ///   Класс, это абстрактные настройки, для игр, что б добавить игру нада наследовать етот класс
    ///   Класс имеет общие настройки для игор
    /// </summary>
    public abstract class GameProperty : RegistryProperty
    {
        protected readonly ListLoaderTask _loader;
        protected readonly Statuses _statuses;

        protected GameProperty()
        {
            _loader = new ListLoaderTask(this);
            _statuses = new Statuses();
            Path = "";
            Installed = false;
            select();
        }

        public bool this[ListFileType type]
        {
            get { return _statuses[type]; }
            set { _statuses[type] = value; }
        }

        public abstract ProcessStartInfo GetStartInfo();
        public abstract String listURL();
        public abstract Game GameEnum();

        public virtual bool isEnable()
        {
            return true;
        }

        #region Propertyes		

        [LanguageDisplayName(WordEnum.INSTALLED)]
        [LanguageDescription(WordEnum.INSTALLED_DESCRIPTION)]
        [RegistryPropertyKey("Installed", false)]
        public bool Installed { get; set; }

        [LanguageDisplayName(WordEnum.PATH_TO_GAME)]
        [LanguageDescription(WordEnum.PATH_TO_GAME_DESCRIPTION)]
        [Editor(typeof (GameDirectorySelect), typeof (UITypeEditor))]
        [RegistryPropertyKey("Path", ".")]
        public String Path { get; set; }

        [Browsable(false)]
        public IGamePanel Panel { get; set; }

        [Browsable(false)]
        public ListLoaderTask ListLoader
        {
            get { return _loader; }
        }

        #endregion
    }
}