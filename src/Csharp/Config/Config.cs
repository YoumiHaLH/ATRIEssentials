#pragma warning disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ATRIEssentialsPluginMainProject.Config
{
    public class Config
    {
        public string version { get; set; } = "0.0.1";

        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public Land land { get; set; } = new Land();

        /// <summary>
        /// 
        /// </summary>
        public Home home { get; set; } = new Home();

        /// <summary>
        /// 
        /// </summary>
        public Warp warp { get; set; } = new Warp();

        /// <summary>
        /// 
        /// </summary>
        public Tpr tpr { get; set; } = new Tpr();

        /// <summary>
        /// 
        /// </summary>
        public Tpa tpa { get; set; } = new Tpa();

        /// <summary>
        /// 
        /// </summary>
        public Menu menu { get; set; } = new Menu();

        /// <summary>
        /// 
        /// </summary>
        public MoreDim moreDim { get; set; } = new MoreDim();

        /// <summary>
        /// 
        /// </summary>
        public PhotoMap photoMap { get; set; } = new PhotoMap();          

        /// <summary>
        /// 
        /// </summary>
        public WebMap WebMap { get; set; } = new WebMap();

        /// <summary>
        /// 
        /// </summary>
        public EmilLogin emilLogin { get; set; } = new EmilLogin();

        /// <summary>
        /// 
        /// </summary>
        public Money money { get; set; } = new Money();

        /// <summary>
        /// 
        /// </summary>
        public Fakemotd fakemotd { get; set; } = new Fakemotd();

        /// <summary>
        /// 
        /// </summary>
        public ScheduleTask ScheduleTask { get; set; } = new ScheduleTask();

        /// <summary>
        /// 
        /// </summary>
        public CommandMap CommandMap { get; set; } = new CommandMap();

        /// <summary>
        /// 
        /// </summary>
        public Shop Shop { get; set; } = new Shop();

        /// <summary>
        /// 
        /// </summary>
        public PvPManager PvPManager { get; set; } = new PvPManager();

        /// <summary>
        /// 
        /// </summary>
        public TransferServerOnClose TransferServerOnClose { get; set; } = new TransferServerOnClose();

        /// <summary>
        /// 
        /// </summary>
        public BehaviorLog BehaviorLog { get; set; } = new BehaviorLog();

        /// <summary>
        /// 
        /// </summary>
        public AttackEcho AttackEcho { get; set; } = new AttackEcho();

        /// <summary>
        /// 
        /// </summary>
        public ChatEnhancement ChatEnhancement { get; set; } = new ChatEnhancement();

        /// <summary>
        /// 
        /// </summary>
        public ChatTranslation ChatTranslation { get; set; } = new ChatTranslation();

        /// <summary>
        /// 
        /// </summary>
        public Death Death { get; set; } = new Death();

        /// <summary>
        /// 
        /// </summary>
        public WorldLimit WorldLimit { get; set; } = new WorldLimit();

        /// <summary>
        /// 
        /// </summary>
        public Notice Notice { get; set; } = new Notice();


        /// <summary>
        /// 
        /// </summary>
        public FriendlyDisconnect FriendlyDisconnect { get; set; } = new FriendlyDisconnect();

        /// <summary>
        /// 
        /// </summary>
        public Helper Helper { get; set; } = new Helper();

        /// <summary>
        /// 
        /// </summary>
        public BelowName BelowName { get; set; } = new BelowName();

        /// <summary>
        /// 
        /// </summary>
        public JoinLocation JoinLocation { get; set; } = new JoinLocation();

        /// <summary>
        /// 
        /// </summary>
        public Sidebar Sidebar { get; set; } = new Sidebar();   
    }
    public class Land
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class Home
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class Warp
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class Tpr
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class Tpa
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class Menu
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }
    public class MoreDim
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class PhotoMap
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class WebMap
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class EmilLogin
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class Money
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class Fakemotd
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class ScheduleTask
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class CommandMap
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class Shop
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class PvPManager
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class TransferServerOnClose
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class BehaviorLog
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class AttackEcho
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class ChatEnhancement
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class ChatTranslation
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class Death
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class WorldLimit
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class Notice
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class FriendlyDisconnect
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class Helper
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class BelowName
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class JoinLocation
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

    public class Sidebar
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isEnable { get; set; } = false;
    }

}
