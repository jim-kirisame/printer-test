using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrinterTest
{
    public class EscPosCommand
    {
        /// <summary>
        /// 初始化打印机指令
        /// </summary>
        /// <returns></returns>
        public byte[] Init()
        {
            return new byte[2] { 0x1b, 0x40 };
        }

        /// <summary>
        /// 走纸到左黑标
        /// </summary>
        /// <returns></returns>
        public byte[] ToLeftBlackPos()
        {
            return new byte[1] { 0x0c };
        }

        /// <summary>
        /// 走纸到右黑标
        /// </summary>
        /// <returns></returns>
        public byte[] ToRightBlackPos()
        {
            return new byte[1] { 0x0E };
        }

        /// <summary>
        /// 设置字间距
        /// </summary>
        /// <param name="spacing"></param>
        /// <returns></returns>
        public byte[] SetWordSpacing(uint spacing)
        {
            return new byte[3] { 0x1b, 0x20, (byte)spacing };
        }

        /// <summary>
        /// 设置行间距
        /// </summary>
        /// <param name="spacing"></param>
        /// <returns></returns>
        public byte[] SetLineSpacing(uint spacing)
        {
            return new byte[3] { 0x1b, 0x33, (byte)spacing };
        }

        /// <summary>
        /// 设置左边距
        /// </summary>
        /// <param name="padding"></param>
        /// <returns></returns>
        public byte[] SetLeftPadding(uint padding)
        {
            byte lByte = (byte)(padding % 256);
            byte hByte = (byte)(padding / 256);
            return new byte[4] { 0x1d, 0x4c, lByte, hByte };
        }

        /// <summary>
        /// 设置/取消粗体
        /// </summary>
        /// <param name="bold">是否设置粗体</param>
        /// <returns></returns>
        public byte[] SetBold(bool bold)
        {
            return new byte[3] { 0x1b, 0x45, (byte)(bold ? 0x01 : 0x00) };
        }

        /// <summary>
        /// 设置/取消下划线
        /// </summary>
        /// <param name="ul">下划线宽度，可为0/1/2</param>
        /// <returns></returns>
        public byte[] SetUnderline(uint width)
        {
            return new byte[3] { 0x1b, 0x2d, (byte)width };
        }

        /// <summary>
        /// 设置/取消反色显示
        /// </summary>
        /// <param name="reverse">是否反色</param>
        /// <returns></returns>
        public byte[] SetReverse(bool reverse)
        {
            return new byte[3] { 0x1d, 0x42, (byte)(reverse ? 0x01 : 0x00) };
        }

        /// <summary>
        /// 打印并进纸指定行数
        /// </summary>
        /// <param name="line">进纸行数</param>
        /// <returns></returns>
        public byte[] PrintAndMoveLines(uint lines)
        {
            return new byte[3] { 0x1b, 0x64, (byte)lines };
        }

        /// <summary>
        /// 打印并进纸指定点数
        /// </summary>
        /// <param name="line">进纸行数</param>
        /// <returns></returns>
        public byte[] PrintAndMovePoints(uint points)
        {
            return new byte[3] { 0x1b, 0x4a, (byte)points };
        }

        /// <summary>
        /// 设置字符旋转
        /// </summary>
        /// <param name="type">旋转方向。1：90°，2：180°，3：270°，0：0°</param>
        /// <returns></returns>
        public byte[] SetRotate(byte type)
        {
            return new byte[3] { 0x1b, 0x56, type };
        }

        /// <summary>
        /// 打印条形码
        /// </summary>
        /// <remarks>
        /// 参见zicox的Esc/Pos文档以获取更多信息
        /// </remarks>
        /// <param name="type">条形码类型</param>
        /// <param name="data">条形码数据</param>
        /// <returns></returns>
        public byte[] PrintBarCode(byte type, byte[] data)
        {
            byte[] command = new byte[3] { 0x1d, 0x6b, type };
            return command.Concat(data).ToArray();
        }

        /// <summary>
        /// 获取打印机当前状态
        /// </summary>
        /// <returns></returns>
        public byte[] GetStatus()
        {
            return new byte[] { 0x1d, 0x99 };
        }

        /// <summary>
        /// 设置对齐
        /// </summary>
        /// <param name="type">0：左对齐，1：居中，2：右对齐</param>
        /// <returns></returns>
        public byte[] SetAlign(byte type)
        {
            return new byte[] { 0x1b, 0x61, type };
        }

        /// <summary>
        /// 设置打印位置与开头的间距
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public byte[] SetPrintPos(uint pos)
        {
            byte lByte = (byte)(pos % 256);
            byte hByte = (byte)(pos / 256);
            return new byte[4] { 0x1b, 0x24, lByte, hByte };
        }

        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="type">字体类型</param>
        /// <returns></returns>
        public byte[] SetFont(byte type)
        {
            return new byte[] { 0x1b, 0x4d, type };
        }
    }
}
