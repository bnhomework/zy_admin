using System;
using System.Collections.Generic;

namespace Bn.WeiXin.Messages
{
    public class WxMessage
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public int CreateTime { get; set; }
        public string MsgType { get; set; }

        protected int ConvertDateTimeInt(DateTime time)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
    }

    #region Request

    public class WxRequest : WxMessage
    {
        public IWxMessageHandler MessageHandler { get; set; }

        public virtual string HandleMessage()
        {
            if (MessageHandler == null)
            {
                throw new InvalidOperationException("MessageHandler is not defined");
            }
            return "";
        }
        
    }

    public class TextWxRequest : WxRequest
    {
        public string Content { get; set; }
        public string MsgId { get; set; }
        public override string HandleMessage()
        {
            base.HandleMessage();
            return MessageHandler.OnTextMessageReceived(this);
        }
    }
    public class ImageWxRequest : WxRequest
    {
        public string PicUrl { get; set; }
        public string MediaId { get; set; }
        public string MsgId { get; set; }
        public override string HandleMessage()
        {
            base.HandleMessage();
            return MessageHandler.OnImageMessageReceived(this);
        }
    }
    public class VoiceWxRequest : WxRequest
    {
        public string Format { get; set; }
        public string MediaId { get; set; }
        public string MsgId { get; set; }
        //��ͨ����ʶ���ܣ��û�ÿ�η������������ں�ʱ��
        //΢�Ż������͵�������ϢXML���ݰ��У�����һ��Recongnition�ֶ�
        public string Recognition { get; set; }
    }
    public class VideoWxRequest : WxRequest
    {
        public string ThumbMediaId { get; set; }
        public string MediaId { get; set; }
        public string MsgId { get; set; }
    }
    //����λ����Ϣ
    public class LocationWxRequest : WxRequest
    {
        public string Location_X { get; set; }
        public string Location_Y { get; set; }
        public string Scale { get; set; }
        public string Label { get; set; }
        public string MsgId { get; set; }
    }
    public class LinkWxRequest : WxRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string MsgId { get; set; }
    }

    //������Ϣ
    //��ע/ȡ����ע�¼�
    //Event	 �¼����ͣ�subscribe(����)��unsubscribe(ȡ������)
    //ɨ���������ά���¼�
    //    1. �û�δ��עʱ�����й�ע����¼�����    
    //    Event	 �¼����ͣ�subscribe
    //EventKey	 �¼�KEYֵ��qrscene_Ϊǰ׺������Ϊ��ά��Ĳ���ֵ
    //    2. �û��ѹ�עʱ���¼�����
    //    Event	 �¼����ͣ�scan
    //EventKey	 �¼�KEYֵ����һ��32λ�޷�������
    //LOCATION
    //Click
    public class EventWxRequest : WxRequest
    {
        public string Event { get; set; }

        public string EventKey { get; set; }
        public string Ticket { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Precision { get; set; }

        public override string HandleMessage()
        {
            string defaultValue = base.HandleMessage();

            switch (Event)
            {
                case "subscribe":
                    return MessageHandler.OnSubscribe(this);
                case "unsubscribe":
                    return MessageHandler.OnUserExit(this);
                case "CLICK":
                    return MessageHandler.OnMenuButtonClick(this, EventKey);
                case "VIEW":
                    return MessageHandler.OnMenuLinkClick(this, EventKey);
                default:
                    return defaultValue;
            }
        }
    }

    #endregion

    //���ͱ�����Ӧ��Ϣ
    #region Response

    public class WxResponseXml : WxMessage
    {
        public WxResponseXml(WxRequest request)
        {
            this.FromUserName = request.ToUserName;
            this.ToUserName = request.FromUserName;
            this.CreateTime = ConvertDateTimeInt(DateTime.Now);
        }
    }
    public class TextWxResponseXml : WxResponseXml
    {
        public TextWxResponseXml(WxRequest request)
            : base(request)
        {
            this.MsgType = "text";
        }
        public string Content { get; set; }
    }
    public class NewsWxResponseXml : WxResponseXml
    {
        public NewsWxResponseXml(WxRequest request)
            : base(request)
        {
            this.MsgType = "news";
        }
        public int ArticleCount {
            get { return Articles==null?0:Articles.Count; }
        }

        public List<ArticleItem> Articles { get; set; }
    }

    public class ImageWxResponseXml : WxResponseXml
    {
        public ImageWxResponseXml(WxRequest request)
            : base(request)
        {
            this.MsgType = "image";
        }
        public Media Image { get; set; }
    }
    public class VoiceWxResponseXml : WxResponseXml
    {
        public VoiceWxResponseXml(WxRequest request)
            : base(request)
        {
            this.MsgType = "voice";
        }
        public Media Voice { get; set; }
    }
    public class VideoWxResponseXml : WxResponseXml
    {
        public VideoWxResponseXml(WxRequest request)
            : base(request)
        {
            this.MsgType = "video";
        }
        public Video Video { get; set; }
    }
    public class MusicWxResponseXml : WxResponseXml
    {
        public MusicWxResponseXml(WxRequest request)
            : base(request)
        {
            this.MsgType = "music";
        }
        public Music Music { get; set; }
    }
   


    public class Media : InnerType
    {
        public string MediaId { get; set; }
    }
    public class Video : Media
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class Music : InnerType
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MusicUrl { get; set; }
        public string HqMusicUrl { get; set; }
        public string ThumbMediaId { get; set; }
    }
    public class ArticleItem : InnerType
    {
        public Article item { get; set; }
    }
    public class Article : InnerType
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public string Url { get; set; }
    }
    public interface InnerType
    { }

    #endregion
}