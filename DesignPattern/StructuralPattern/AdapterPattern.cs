using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.StructuralPattern
{
    public enum AudioTypeEnum
    {
        MP3 = 0,
        MP4,
        VLC
    }

    public interface IMediaPlayer
    {
        public void play(AudioTypeEnum audioType, string fileName);
    }

    /// <summary>
    /// adaptee
    /// IAdvanceMediaPlayer里有高级功能，是IMediaPlayer的实例希望添加的新功能
    /// </summary>
    public interface IAdvanceMediaPlayer
    {
        public void playVlc(string fileName);
        public void playMP4(string fileName);
    }

    /// <summary>
    /// 继承了IAdvanceMediaPlayer的实体类MP4Player/VLCPlayer
    /// </summary>
    public class MP4Player : IAdvanceMediaPlayer
    {
        public void playMP4(string fileName)
        {
            Console.WriteLine($"playing MP4 file: {fileName}");
        }

        public void playVlc(string fileName)
        {
            throw new NotImplementedException();
        }
    }
    public class VLCPlayer : IAdvanceMediaPlayer
    {
        public void playMP4(string fileName)
        {
            throw new NotImplementedException();
        }

        public void playVlc(string fileName)
        {
            Console.WriteLine($"playing VLC file: {fileName}");
        }
    }

    #region instance adapter
    /// <summary>
    /// adapter. 对象适配器模式
    /// adapter里有adaptee的实例
    /// </summary>
    public class MediaAdapter : IMediaPlayer
    {
        IAdvanceMediaPlayer m_advancePlayer;

        public MediaAdapter(AudioTypeEnum audioType)
        {
            if (audioType == AudioTypeEnum.MP4)
                m_advancePlayer = new MP4Player();
            else if (audioType == AudioTypeEnum.VLC)
                m_advancePlayer = new VLCPlayer();
            else
            {
                throw new Exception("invalid advance type");
            }
        }

        public void play(AudioTypeEnum audioType, string fileName)
        {
            //adapter通过调用m_advancePlayer实现advance功能。
            if (audioType == AudioTypeEnum.MP4)
                m_advancePlayer.playMP4(fileName);
            else if (audioType == AudioTypeEnum.VLC)
                m_advancePlayer.playVlc(fileName);
            else
                Console.WriteLine("invalid type");
        }
    }

    /// <summary>
    /// target
    /// 本来只有play mp3的功能。希望扩展播放其他音频的功能。在类内通过调用adapter里的advance的对象实现。
    /// </summary>
    public class AudioPlayer : IMediaPlayer
    {
        //这里用接口更好，依赖抽象，而不是具体的类，接口被改动的几率比较小
        //MediaAdapter m_mediaAdapter = null;
        IMediaPlayer m_mediaAdapter = null;

        /// <summary>
        /// mp3 + mp4/vlc(new added to AudioPlayer class)
        /// </summary>
        /// <param name="audioType"></param>
        /// <param name="fileName"></param>
        public void play(AudioTypeEnum audioType, string fileName)
        {
            if (audioType == AudioTypeEnum.MP3)
                Console.WriteLine($"playing mp3: {fileName}");
            else if (audioType == AudioTypeEnum.MP4 || audioType == AudioTypeEnum.VLC)
            {
                //通过adapter调用，所以adapter里需要实现advance的功能
                m_mediaAdapter = new MediaAdapter(audioType);
                m_mediaAdapter.play(audioType, fileName);
            }
            else
            {
                Console.WriteLine($"invalid media type {audioType}, format not support");
            }
        }
    }
    #endregion

    /// <summary>
    /// 自己实现的类适配器模式，可能不是很好。感觉还是对象型的适配器好一点
    /// </summary>
    #region class adapter
    public class MediaClassAdapter : MP4Player, IMediaPlayer
    {
        public void play(AudioTypeEnum audioType, string fileName)
        {
            base.playMP4(fileName);
            throw new NotImplementedException();
        }
    }

    public class ClassPatternAudioPlayer : IMediaPlayer
    {
        public void play(AudioTypeEnum audioType, string fileName)
        {
            if (audioType == AudioTypeEnum.MP3)
                Console.WriteLine($"playing mp3: {fileName}");
            else if (audioType == AudioTypeEnum.MP4)
            {
                MediaClassAdapter adap = new MediaClassAdapter();
                adap.playMP4(fileName);
            }
            else
            {
                Console.WriteLine($"invalid media type {audioType}, format not support");
            }
        }
    }
    #endregion
}
