using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CustomDataScouting
{
    // カスタム属性の定義
    [AttributeUsage(AttributeTargets.Field)]
    public class CharacterNameAttribute : Attribute
    {
        public string English { get; }
        public string Japanese { get; }
        public string Korean { get; }

        public CharacterNameAttribute(string english, string japanese, string korean)
        {
            English = english;
            Japanese = japanese;
            Korean = korean;
        }
    }

    /// <summary>
    /// SubjectNameの拡張メソッドを管理するクラス
    /// </summary>
    public static class SubjectNameExtensions
    {
        
        private static CharacterNameAttribute? GetAttr(this SubjectName value)
        {
            var field = value.GetType().GetField(value.ToString());
            return field?.GetCustomAttributes(typeof(CharacterNameAttribute), false)
                         .FirstOrDefault() as CharacterNameAttribute;
        }
        /// <summary>
        /// 日本語名で返却する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToJapanese(this SubjectName value) => GetAttr(value)?.Japanese ?? value.ToString();

        
        public static string ToKorean(this SubjectName value) => GetAttr(value)?.Korean ?? value.ToString();



    }

    /// <summary>
    /// 実験体名を管理する列挙型
    /// </summary>
    public enum SubjectName
    {
        [CharacterName("Jackie", "ジャッキー", "재키")] 
        Jackie,
        [CharacterName("Aya", "アヤ", "아야")]
        Aya,
        [CharacterName("Fiora", "フィオラ", "피오라")] 
        Fiora,
        [CharacterName("Magnus", "マグヌス", "매그너스")]
        Magnus,
        [CharacterName("Zahir", "ザヒル", "자히르")]
        Zahir,
        [CharacterName("Nadine", "ナディン", "나딘")]
        Nadine,
        [CharacterName("Hyunwoo", "ヒョヌ", "현우")]
        Hyunwoo,
        [CharacterName("Hart", "ハート", "하트")]
        Hart,
        [CharacterName("Isol", "アイソル", "아이솔")]
        Isol,
        [CharacterName("LiDailin", "ダイリン", "리 다이린")]
        LiDailin,
        [CharacterName("Yuki", "雪", "유키")]
        Yuki,
        [CharacterName("Hyejin", "ヘジン", "혜진")]
        Hyejin,
        [CharacterName("Xiukai", "シウカイ", "쇼우")]
        Xiukai,
        [CharacterName("Chiara", "キアラ", "키아라")]
        Chiara,
        [CharacterName("Sissela", "シセラ", "시셀라")]
        Sissela,
        [CharacterName("Silvia", "シルヴィア", "실비아")]
        Silvia,
        [CharacterName("Adriana", "アドリアナ", "아드리아나")]
        Adriana,
        [CharacterName("Shoichi", "彰一", "쇼이치")]
        Shoichi,
        [CharacterName("Emma", "エマ", "엠마")]
        Emma,
        [CharacterName("Lenox", "レノックス", "레녹스")]
        Lenox,
        [CharacterName("Rozzi", "ロッジ", "로지")]
        Rozzi,
        [CharacterName("Luke", "ルク", "루크")]
        Luke,
        [CharacterName("Cathy", "キャッシー", "캐시")]
        Cathy,
        [CharacterName("Adela", "アデラ", "아델라")]
        Adela,
        [CharacterName("Bernice", "バニス", "버니스")]
        Bernice,
        [CharacterName("Barbara", "バーバラ", "바바라")]
        Barbara,
        [CharacterName("Alex", "アレックス", "알렉스")]
        Alex,
        [CharacterName("Sua", "スア", "수아")]
        Sua,
        [CharacterName("Leon", "レオン", "레온")]
        Leon,
        [CharacterName("Eleven", "Eleven", "일레븐")]
        Eleven,
        [CharacterName("Rio", "莉央", "리오")]
        Rio,
        [CharacterName("William", "ウィリアム", "윌리엄")]
        William,
        [CharacterName("Nicky", "ニッキー", "니키")]
        Nicky,
        [CharacterName("Nathapon", "ナタポン", "나타폰")]
        Nathapon,
        [CharacterName("Jan", "ヤン", "얀")]
        Jan,
        [CharacterName("Eva", "エヴァ", "이바")]
        Eva,
        [CharacterName("Daniel", "ダニエル", "다니엘")] 
        Daniel,
        [CharacterName("Jenny", "ジェニー", "제니")] 
        Jenny,
        [CharacterName("Camilo", "カミロ", "카밀로")] 
        Camilo,
        [CharacterName("Chloe", "クロエ", "클로에")] 
        Chloe,
        [CharacterName("Johann", "ヨハン", "요한")] 
        Johann,
        [CharacterName("Bianca", "ビアンカ", "비앙카")] 
        Bianca,
        [CharacterName("Celine", "セリーヌ", "셀린")] 
        Celine,
        [CharacterName("Echion", "エキオン", "에키온")]
        Echion,
        [CharacterName("Mai", "マイ", "마이")] 
        Mai,
        [CharacterName("Aiden", "エイデン", "에이든")] 
        Aiden,
        [CharacterName("Laura", "ラウラ", "라우라")] 
        Laura,
        [CharacterName("Tia", "ティア", "띠아")] 
        Tia,
        [CharacterName("Felix", "フェリックス", "펠릭스")] 
        Felix,
        [CharacterName("Elena", "エレナ", "엘레나")] 
        Elena,
        [CharacterName("Priya", "プリヤ", "프리야")]
        Priya,
        [CharacterName("Adina", "アディナ", "아디나")] 
        Adina,
        [CharacterName("Markus", "マーカス", "마커스")] 
        Markus,
        [CharacterName("Karla", "カーラ", "칼라")] 
        Karla,
        [CharacterName("Estelle", "エステル", "에스텔")] 
        Estelle,
        [CharacterName("Piolo", "ピオロ", "피올로")] 
        Piolo,
        [CharacterName("Martina", "マルティナ", "마르티나")] 
        Martina,
        [CharacterName("Haze", "ヘイズ", "헤이즈")]
        Haze,
        [CharacterName("Isaac", "アイザック", "아이작")] 
        Isaac,
        [CharacterName("Tazia", "タジア", "타지아")] 
        Tazia,
        [CharacterName("Irem", "イレム", "이렘")] 
        Irem,
        [CharacterName("Theodore", "テオドール", "테오도르")] 
        Theodore,
        [CharacterName("LyAnh", "イアン", "이안")] 
        LyAnh,
        [CharacterName("Vanya", "ヴァーニャ", "바냐")] 
        Vanya,
        [CharacterName("DebiMarlene", "デビー&マーリン", "데비&마를렌")]
        DebiMarlene,
        [CharacterName("Arda", "アルダ", "아르다")] 
        Arda,
        [CharacterName("Abigail", "アビゲイル", "아비게일")] 
        Abigail,
        [CharacterName("Alonso", "アロンソ", "알론소")] 
        Alonso,
        [CharacterName("Leni", "レニ", "레니")] 
        Leni,
        [CharacterName("Tsubame", "つばめ", "츠바메")] 
        Tsubame,
        [CharacterName("Kenneth", "ケネス", "케네스")] 
        Kenneth,
        [CharacterName("Katja", "カティア", "카티야")] 
        Katja,
        [CharacterName("Charlotte", "シャーロット", "샬럿")] 
        Charlotte,
        [CharacterName("Darko", "ダルコ", "다르코")] 
        Darko,
        [CharacterName("Lenore", "レノア", "레노아")] 
        Lenore,
        [CharacterName("Garnet", "ガーネット", "가넷")] 
        Garnet,
        [CharacterName("YuMin", "ユミン", "유민")] 
        YuMin,
        [CharacterName("Hisui", "ヒスイ", "히스이")] 
        Hisui,
        [CharacterName("Justyna", "ユスティナ", "유스티나")] 
        Justyna,
        [CharacterName("Istvan", "イシュトヴァーン", "이슈트반")] 
        Istvan,
        [CharacterName("NiaH", "ニア", "니아")] 
        NiaH,
        [CharacterName("Xuelin", "シュリン", "슈린")] 
        Xuelin,
        [CharacterName("Henry", "ヘンリー", "헨리")] 
        Henry,
        [CharacterName("Blair", "ブレア", "블레어")] 
        Blair,
        [CharacterName("Mirka", "ミルカ", "미르카")] 
        Mirka,
        [CharacterName("Fenrir", "フェンリル", "펜리르")] 
        Fenrir,
        [CharacterName("Coraline", "コラライン", "코렐라인")] 
        Coraline,
        [CharacterName("Bihyung", "ビヒョン", "비형")] 
        Bihyung,
        [CharacterName("Other", "Other", "Other")] 
        Other,
    }
}
